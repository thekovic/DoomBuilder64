
#region ================== Copyright (c) 2007 Pascal vd Heiden

/*
 * Copyright (c) 2007 Pascal vd Heiden, www.codeimp.com
 * This program is released under GNU General Public License
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 */

#endregion

#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using CodeImp.DoomBuilder.Windows;
using CodeImp.DoomBuilder.IO;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Editing;
using CodeImp.DoomBuilder.Rendering;
using CodeImp.DoomBuilder.Data;
using CodeImp.DoomBuilder.Actions;
using CodeImp.DoomBuilder.Config;
using CodeImp.DoomBuilder.Plugins;
using CodeImp.DoomBuilder.Compilers;
using CodeImp.DoomBuilder.VisualModes;

#endregion

namespace CodeImp.DoomBuilder
{
    public sealed class MapManager
    {
        #region ================== Constants

        // Map header name in temporary file
        internal const string TEMP_MAP_HEADER = "TEMPMAP";
        internal const string BUILD_MAP_HEADER = "MAP01";
        public const string CONFIG_MAP_HEADER = "~MAP";

        #endregion

        #region ================== Variables

        // Status
        private bool changed;
        private bool scriptschanged;
        private bool maploading;

        // Map information
        private string filetitle;
        private string filepathname;
        private string temppath;

        // Main objects
        private MapSet map;
        private MapSetIO io;
        private MapOptions options;
        private ConfigurationInfo configinfo;
        private GameConfiguration config;
        private DataManager data;
        private D3DDevice graphics;
        private Renderer2D renderer2d;
        private Renderer3D renderer3d;
        private WAD tempwad;
        private GridSetup grid;
        private UndoManager undoredo;
        private CopyPasteManager copypaste;
        private Launcher launcher;
        private ThingsFilter thingsfilter;
        private ScriptEditorForm scriptwindow;
        private List<CompilerError> errors;
        private VisualCamera visualcamera;

        // villsa
        private List<uint> hashkeys;
        private List<string> hashkeynames;

        // Disposing
        private bool isdisposed = false;

        #endregion

        #region ================== Properties

        // villsa
        public List<uint> TextureHashKey { get { return hashkeys; } }
        public List<string> TextureHashName { get { return hashkeynames; } }

        public string FilePathName { get { return filepathname; } }
        public string FileTitle { get { return filetitle; } }
        public string TempPath { get { return temppath; } }
        public MapOptions Options { get { return options; } }
        public MapSet Map { get { return map; } }
        public DataManager Data { get { return data; } }
        public bool IsChanged { get { return changed | CheckScriptChanged(); } set { changed |= value; if (!maploading) General.MainWindow.UpdateMapChangedStatus(); } }
        public bool IsDisposed { get { return isdisposed; } }
        internal D3DDevice Graphics { get { return graphics; } }
        public IRenderer2D Renderer2D { get { return renderer2d; } }
        public IRenderer3D Renderer3D { get { return renderer3d; } }
        internal Renderer2D CRenderer2D { get { return renderer2d; } }
        internal Renderer3D CRenderer3D { get { return renderer3d; } }
        public GameConfiguration Config { get { return config; } }
        internal ConfigurationInfo ConfigSettings { get { return configinfo; } }
        public GridSetup Grid { get { return grid; } }
        public UndoManager UndoRedo { get { return undoredo; } }
        internal CopyPasteManager CopyPaste { get { return copypaste; } }
        public IMapSetIO FormatInterface { get { return io; } }
        internal Launcher Launcher { get { return launcher; } }
        public ThingsFilter ThingsFilter { get { return thingsfilter; } }
        internal List<CompilerError> Errors { get { return errors; } }
        internal ScriptEditorForm ScriptEditor { get { return scriptwindow; } }
        public VisualCamera VisualCamera { get { return visualcamera; } set { visualcamera = value; } }
        public bool IsScriptsWindowOpen { get { return (scriptwindow != null) && !scriptwindow.IsDisposed; } }

        #endregion

        #region ================== Constructor / Disposer

        // Constructor
        internal MapManager()
        {
            // We have no destructor
            GC.SuppressFinalize(this);

            // Create temporary path
            temppath = General.MakeTempDirname();
            Directory.CreateDirectory(temppath);
            General.WriteLogLine("Temporary directory:  " + temppath);

            // Basic objects
            grid = new GridSetup();
            undoredo = new UndoManager();
            copypaste = new CopyPasteManager();
            launcher = new Launcher(this);
            thingsfilter = new NullThingsFilter();
            errors = new List<CompilerError>();

            // villsa
            hashkeys = new List<uint>();
            hashkeynames = new List<string>();
        }

        // Disposer
        internal bool Dispose()
        {
            // Not already disposed?
            if (!isdisposed)
            {
                // Let the plugins know
                General.Plugins.OnMapCloseBegin();

                // Stop processing
                General.MainWindow.StopProcessing();

                // Close script editor
                CloseScriptEditor(false);

                // Change to no mode
                General.Editing.ChangeMode((EditMode)null);

                // Unbind any methods
                General.Actions.UnbindMethods(this);

                // Dispose
                maploading = true;
                if (grid != null) grid.Dispose();
                if (launcher != null) launcher.Dispose();
                if (copypaste != null) copypaste.Dispose();
                if (undoredo != null) undoredo.Dispose();
                General.WriteLogLine("Unloading data resources...");
                if (data != null) data.Dispose();
                General.WriteLogLine("Closing temporary file...");
                if (tempwad != null) tempwad.Dispose();
                General.WriteLogLine("Unloading map data...");
                if (map != null) map.Dispose();
                General.WriteLogLine("Stopping graphics device...");
                if (renderer2d != null) renderer2d.Dispose();
                if (renderer3d != null) renderer3d.Dispose();
                if (graphics != null) graphics.Dispose();
                visualcamera = null;
                grid = null;
                launcher = null;
                copypaste = null;
                undoredo = null;
                data = null;
                tempwad = null;
                map = null;
                renderer2d = null;
                renderer3d = null;
                graphics = null;

                // villsa
                hashkeys = null;
                hashkeynames = null;

                // We may spend some time to clean things up here
                GC.Collect();

                // Remove temp file
                General.WriteLogLine("Removing temporary directory...");
                try { Directory.Delete(temppath, true); }
                catch (Exception e)
                {
                    General.WriteLogLine(e.GetType().Name + ": " + e.Message);
                    General.WriteLogLine("Failed to remove temporary directory!");
                }

                // Let the plugins know
                General.Plugins.OnMapCloseEnd();

                // Done
                isdisposed = true;
                return true;
            }
            else
            {
                // Already closed
                return true;
            }
        }

        #endregion

        #region ================== New / Open

        // Initializes for a new map
        internal bool InitializeNewMap(MapOptions options)
        {
            string tempfile;

            // Apply settings
            this.filetitle = "unnamed.wad";
            this.filepathname = "";
            this.maploading = true;
            this.changed = false;
            this.options = options;

            General.WriteLogLine("Creating new map '" + options.CurrentName + "' with configuration '" + options.ConfigFile + "'");

            // Initiate graphics
            General.WriteLogLine("Initializing graphics device...");
            graphics = new D3DDevice(General.MainWindow.Display);
            if (!graphics.Initialize()) return false;

            // Create renderers
            renderer2d = new Renderer2D(graphics);
            renderer3d = new Renderer3D(graphics);

            // Load game configuration
            General.WriteLogLine("Loading game configuration...");
            configinfo = General.GetConfigurationInfo(options.ConfigFile);
            config = new GameConfiguration(General.LoadGameConfiguration(options.ConfigFile));
            configinfo.ApplyDefaults(config);
            General.Editing.UpdateCurrentEditModes();

            // Create map data
            map = new MapSet();

            // Create temp wadfile
            tempfile = General.MakeTempFilename(temppath);
            General.WriteLogLine("Creating temporary file: " + tempfile);
#if DEBUG
				tempwad = new WAD(tempfile);
#else
            try { tempwad = new WAD(tempfile); }
            catch (Exception e)
            {
                General.ShowErrorMessage("Error while creating a temporary wad file:\n" + e.GetType().Name + ": " + e.Message, MessageBoxButtons.OK);
                return false;
            }
#endif

            // Read the map from temp file
            General.WriteLogLine("Initializing map format interface " + config.FormatInterface + "...");
            io = MapSetIO.Create(config.FormatInterface, tempwad, this);

            // Create required lumps
            General.WriteLogLine("Creating map data structures...");
            tempwad.Insert(TEMP_MAP_HEADER, 0, 0);
            io.Write(map, TEMP_MAP_HEADER, 1);
            CreateRequiredLumps(tempwad, TEMP_MAP_HEADER);

            // Load data manager
            General.WriteLogLine("Loading data resources...");
            data = new DataManager();
            data.Load(configinfo.Resources, options.Resources);

            // Update structures
            options.ApplyGridSettings();
            map.UpdateConfiguration();
            map.Update();
            thingsfilter.Update();

            // Bind any methods
            General.Actions.BindMethods(this);

            // Set defaults
            this.visualcamera = new VisualCamera();
            General.Editing.ChangeMode(configinfo.StartMode);
            ClassicMode cmode = (General.Editing.Mode as ClassicMode);
            if (cmode != null) cmode.SetZoom(0.5f);
            renderer2d.SetViewMode((ViewMode)General.Settings.DefaultViewMode);
            General.Settings.SetDefaultThingFlags(config.DefaultThingFlags);

            // Success
            this.changed = false;
            this.maploading = false;
            General.WriteLogLine("Map creation done");
            General.MainWindow.UpdateMapChangedStatus();
            return true;
        }

        // Initializes for an existing map
        internal bool InitializeOpenMap(string filepathname, MapOptions options)
        {
            WAD mapwad;
            string tempfile;
            DataLocation maplocation;

            // Apply settings
            this.filetitle = Path.GetFileName(filepathname);
            this.filepathname = filepathname;
            this.changed = false;
            this.maploading = true;
            this.options = options;

            General.WriteLogLine("Opening map '" + options.CurrentName + "' with configuration '" + options.ConfigFile + "'");

            // Initiate graphics
            General.WriteLogLine("Initializing graphics device...");
            graphics = new D3DDevice(General.MainWindow.Display);
            if (!graphics.Initialize()) return false;

            // Create renderers
            renderer2d = new Renderer2D(graphics);
            renderer3d = new Renderer3D(graphics);

            // Load game configuration
            General.WriteLogLine("Loading game configuration...");
            configinfo = General.GetConfigurationInfo(options.ConfigFile);
            config = new GameConfiguration(General.LoadGameConfiguration(options.ConfigFile));
            configinfo.ApplyDefaults(config);
            General.Editing.UpdateCurrentEditModes();

            // Create map data
            map = new MapSet();

            // Create temp wadfile
            tempfile = General.MakeTempFilename(temppath);
            General.WriteLogLine("Creating temporary file: " + tempfile);
#if DEBUG
				tempwad = new WAD(tempfile);
#else
            try { tempwad = new WAD(tempfile); }
            catch (Exception e)
            {
                General.ShowErrorMessage("Error while creating a temporary wad file:\n" + e.GetType().Name + ": " + e.Message, MessageBoxButtons.OK);
                return false;
            }
#endif

            // Now open the map file
            General.WriteLogLine("Opening source file: " + filepathname);
#if DEBUG
				mapwad = new WAD(filepathname, true);
#else
            try { mapwad = new WAD(filepathname, true); }
            catch (Exception e)
            {
                General.ShowErrorMessage("Error while opening source wad file:\n" + e.GetType().Name + ": " + e.Message, MessageBoxButtons.OK);
                return false;
            }
#endif

            // Copy the map lumps to the temp file
            General.WriteLogLine("Copying map lumps to temporary file...");
            CopyLumpsByType(mapwad, options.CurrentName, tempwad, TEMP_MAP_HEADER,
                            true, true, true, true);

            // Close the map file
            mapwad.Dispose();

            // Read the map from temp file
            map.BeginAddRemove();
            General.WriteLogLine("Initializing map format interface " + config.FormatInterface + "...");
            io = MapSetIO.Create(config.FormatInterface, tempwad, this);
            General.WriteLogLine("Reading map data structures from file...");
#if DEBUG
				map = io.Read(map, TEMP_MAP_HEADER);
#else
            try { map = io.Read(map, TEMP_MAP_HEADER); }
            catch (Exception e)
            {
                General.ErrorLogger.Add(ErrorType.Error, "Unable to read the map data structures with the specified configuration. " + e.GetType().Name + ": " + e.Message);
                General.ShowErrorMessage("Unable to read the map data structures with the specified configuration.", MessageBoxButtons.OK);
                return false;
            }
#endif
            map.EndAddRemove();

            // Load data manager
            // villsa - load resources before loading map
            // texture hash table needs to be initialized first
            General.WriteLogLine("Loading data resources...");
            data = new DataManager();
            maplocation = new DataLocation(DataLocation.RESOURCE_WAD, filepathname, options.StrictPatches, false, false);
            data.Load(configinfo.Resources, options.Resources, maplocation);

            // Remove unused sectors
            map.RemoveUnusedSectors(true);

            // Update structures
            options.ApplyGridSettings();
            map.UpdateConfiguration();
            map.SnapAllToAccuracy();
            map.Update();
            thingsfilter.Update();

            // Bind any methods
            General.Actions.BindMethods(this);

            // Set defaults
            this.visualcamera = new VisualCamera();
            General.Editing.ChangeMode(configinfo.StartMode);
            renderer2d.SetViewMode((ViewMode)General.Settings.DefaultViewMode);
            General.Settings.SetDefaultThingFlags(config.DefaultThingFlags);

            // Center map in screen
            if (General.Editing.Mode is ClassicMode) (General.Editing.Mode as ClassicMode).CenterInScreen();

            // Success
            this.changed = false;
            this.maploading = false;
            General.WriteLogLine("Map loading done");
            General.MainWindow.UpdateMapChangedStatus();
            return true;
        }

        #endregion

        #region ================== Save

        // Initializes for an existing map
        internal bool SaveMap(string newfilepathname, SavePurpose purpose)
        {
            MapSet outputset;
            string nodebuildername, settingsfile;
            StatusInfo oldstatus;
            WAD targetwad;
            int index;
            bool includenodes = false;
            string origmapname;
            bool success = true;

            General.WriteLogLine("Saving map to file: " + newfilepathname);

            // Scripts changed?
            bool localscriptschanged = CheckScriptChanged();

            // If the scripts window is open, save the scripts first
            if (IsScriptsWindowOpen) scriptwindow.Editor.ImplicitSave();

            // Only recompile scripts when the scripts have changed
            // (not when only the map changed)
            if (localscriptschanged)
            {
                if (!CompileScriptLumps())
                {
                    // Compiler failure
                    if (errors.Count > 0)
                        General.ShowErrorMessage("Error while compiling scripts: " + errors[0].description, MessageBoxButtons.OK);
                    else
                        General.ShowErrorMessage("Unknown compiler error while compiling scripts!", MessageBoxButtons.OK);
                }
            }

            // Show script window if there are any errors and we are going to test the map
            // and always update the errors on the scripts window.
            if ((errors.Count > 0) && (scriptwindow == null) && (purpose == SavePurpose.Testing)) ShowScriptEditor();
            if (scriptwindow != null) scriptwindow.Editor.ShowErrors(errors);

            // Only write the map and rebuild nodes when the actual map has changed
            // (not when only scripts have changed)
            // Always write map if configuration is a convertor hack
            if (changed || General.Map.FormatInterface.IsConvertor)
            {
                // Make a copy of the map data
                outputset = map.Clone();

                // Remove all flags from all 3D Start things
                foreach (Thing t in outputset.Things)
                {
                    if (t.Type == config.Start3DModeThingType)
                    {
                        // We're not using SetFlag here, this doesn't have to be undone.
                        // Please note that this is totally exceptional!
                        List<string> flagkeys = new List<string>(t.Flags.Keys);
                        foreach (string k in flagkeys) t.Flags[k] = false;
                    }
                }

                // Do we need sidedefs compression?
                if (map.Sidedefs.Count > io.MaxSidedefs)
                {
                    // Compress sidedefs
                    oldstatus = General.MainWindow.Status;
                    General.MainWindow.DisplayStatus(StatusType.Busy, "Compressing sidedefs...");
                    outputset.CompressSidedefs();
                    General.MainWindow.DisplayStatus(oldstatus);

                    // Check if it still doesnt fit
                    if (outputset.Sidedefs.Count > io.MaxSidedefs)
                    {
                        // Problem! Can't save the map like this!
                        General.ShowErrorMessage("Unable to save the map: There are too many unique sidedefs!", MessageBoxButtons.OK);
                        return false;
                    }
                }

                // Check things
                if (map.Things.Count > io.MaxThings)
                {
                    General.ShowErrorMessage("Unable to save the map: There are too many things!", MessageBoxButtons.OK);
                    return false;
                }

                // Check sectors
                if (map.Sectors.Count > io.MaxSectors)
                {
                    General.ShowErrorMessage("Unable to save the map: There are too many sectors!", MessageBoxButtons.OK);
                    return false;
                }

                // Check linedefs
                if (map.Linedefs.Count > io.MaxLinedefs)
                {
                    General.ShowErrorMessage("Unable to save the map: There are too many linedefs!", MessageBoxButtons.OK);
                    return false;
                }

                // Check vertices
                if (map.Vertices.Count > io.MaxVertices)
                {
                    General.ShowErrorMessage("Unable to save the map: There are too many vertices!", MessageBoxButtons.OK);
                    return false;
                }

                // TODO: Check for more limitations

                // Write to temporary file
                General.WriteLogLine("Writing map data structures to file...");
                index = tempwad.FindLumpIndex(TEMP_MAP_HEADER);
                if (index == -1) index = 0;
                io.Write(outputset, TEMP_MAP_HEADER, index);
                outputset.Dispose();

                // Get the corresponding nodebuilder
                nodebuildername = (purpose == SavePurpose.Testing) ? configinfo.NodebuilderTest : configinfo.NodebuilderSave;

                // Build the nodes
                oldstatus = General.MainWindow.Status;
                General.MainWindow.DisplayStatus(StatusType.Busy, "Building map nodes...");
                if (!string.IsNullOrEmpty(nodebuildername))
                    includenodes = BuildNodes(nodebuildername, true);
                else
                    includenodes = false;
                General.MainWindow.DisplayStatus(oldstatus);
            }
            else
            {
                // Check if we have nodebuilder lumps
                includenodes = VerifyNodebuilderLumps(tempwad, TEMP_MAP_HEADER);
            }

            // Suspend data resources
            data.Suspend();

            // Determine original map name
            origmapname = (options.PreviousName != "") ? options.PreviousName : options.CurrentName;

            try
            {
                // Backup existing file, if any
                if (File.Exists(newfilepathname))
                {
                    if (File.Exists(newfilepathname + ".backup3")) File.Delete(newfilepathname + ".backup3");
                    if (File.Exists(newfilepathname + ".backup2")) File.Move(newfilepathname + ".backup2", newfilepathname + ".backup3");
                    if (File.Exists(newfilepathname + ".backup1")) File.Move(newfilepathname + ".backup1", newfilepathname + ".backup2");
                    File.Copy(newfilepathname, newfilepathname + ".backup1");
                }

                // Except when saving INTO another file,
                // kill the target file if it is different from source file
                if ((purpose != SavePurpose.IntoFile) && (newfilepathname != filepathname))
                {
                    // Kill target file
                    if (File.Exists(newfilepathname)) File.Delete(newfilepathname);

                    // Kill .dbs settings file
                    settingsfile = newfilepathname.Substring(0, newfilepathname.Length - 4) + ".dbs";
                    if (File.Exists(settingsfile)) File.Delete(settingsfile);
                }

                // On Save AS we have to copy the previous file to the new file
                if ((purpose == SavePurpose.AsNewFile) && (filepathname != ""))
                {
                    // Copy if original file still exists
                    if (File.Exists(filepathname)) File.Copy(filepathname, newfilepathname, true);
                }

                // If the target file exists, we need to rebuild it
                if (File.Exists(newfilepathname))
                {
                    // Move the target file aside
                    string origwadfile = newfilepathname + ".temp";
                    File.Move(newfilepathname, origwadfile);

                    // Open original file
                    WAD origwad = new WAD(origwadfile, true);

                    // Create new target file
                    targetwad = new WAD(newfilepathname);

                    // Copy all lumps, except the original map
                    CopyAllLumpsExceptMap(origwad, targetwad, origmapname);

                    // Close original file and delete it
                    origwad.Dispose();
                    File.Delete(origwadfile);
                }
                else
                {
                    // Create new target file
                    targetwad = new WAD(newfilepathname);
                }
            }
            catch (IOException)
            {
                General.ShowErrorMessage("IO Error while writing target file: " + newfilepathname + ". Please make sure the location is accessible and not in use by another program.", MessageBoxButtons.OK);
                data.Resume();
                General.WriteLogLine("Map saving failed");
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                General.ShowErrorMessage("Error while accessing target file: " + newfilepathname + ". Please make sure the location is accessible and not in use by another program.", MessageBoxButtons.OK);
                data.Resume();
                General.WriteLogLine("Map saving failed");
                return false;
            }

            // Copy map lumps to target file
            CopyLumpsByType(tempwad, TEMP_MAP_HEADER, targetwad, origmapname, true, true, includenodes, true);

            // Was the map lump name renamed?
            if ((options.PreviousName != options.CurrentName) &&
               (options.PreviousName != ""))
            {
                General.WriteLogLine("Renaming map lump name from " + options.PreviousName + " to " + options.CurrentName);

                // Find the map header in target
                index = targetwad.FindLumpIndex(options.PreviousName);
                if (index > -1)
                {
                    // Rename the map lump name
                    targetwad.Lumps[index].Rename(options.CurrentName);
                    options.PreviousName = "";
                }
                else
                {
                    // Houston, we've got a problem!
                    General.ShowErrorMessage("Error renaming map lump name: the original map lump could not be found!", MessageBoxButtons.OK);
                    options.CurrentName = options.PreviousName;
                    options.PreviousName = "";
                }
            }

            // Done with the target file
            targetwad.Dispose();

            // Resume data resources
            data.Resume();

            // Not saved for testing purpose?
            if (purpose != SavePurpose.Testing)
            {
                // Saved in a different file?
                if (newfilepathname != filepathname)
                {
                    // Keep new filename
                    filepathname = newfilepathname;
                    filetitle = Path.GetFileName(filepathname);

                    // Reload resources
                    ReloadResources();
                }

                try
                {
                    // Open or create the map settings
                    settingsfile = newfilepathname.Substring(0, newfilepathname.Length - 4) + ".dbs";
                    options.WriteConfiguration(settingsfile);
                }
                catch (Exception e)
                {
                    // Warning only
                    General.ErrorLogger.Add(ErrorType.Warning, "Could not write the map settings configuration file. " + e.GetType().Name + ": " + e.Message);
                }

                // Changes saved
                changed = false;
                scriptschanged = false;
            }

            // Success!
            General.WriteLogLine("Map saving done");
            General.MainWindow.UpdateMapChangedStatus();
            return success;
        }

        #endregion

        #region ================== Nodebuild

        // This builds the nodes in the temproary file with the given configuration name
        private bool BuildNodes(string nodebuildername, bool failaswarning)
        {
            NodebuilderInfo nodebuilder;
            string tempfile1, tempfile2, sourcefile;
            bool lumpscomplete = false;
            WAD buildwad;

            // Find the nodebuilder
            nodebuilder = General.GetNodebuilderByName(nodebuildername);
            if (nodebuilder == null)
            {
                // Problem! Can't find that nodebuilder!
                General.ShowWarningMessage("Unable to build the nodes: The configured nodebuilder cannot be found.\nPlease check your game configuration settings!", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // Create the compiler interface that will run the nodebuilder
                // This automatically creates a temporary directory for us
                Compiler compiler = nodebuilder.CreateCompiler();

                // Make temporary filename
                tempfile1 = General.MakeTempFilename(compiler.Location);

                // Make the temporary WAD file
                General.WriteLogLine("Creating temporary build file: " + tempfile1);
#if DEBUG
					buildwad = new WAD(tempfile1);
#else
                try { buildwad = new WAD(tempfile1); }
                catch (Exception e)
                {
                    General.ShowErrorMessage("Error while creating a temporary wad file:\n" + e.GetType().Name + ": " + e.Message, MessageBoxButtons.OK);
                    return false;
                }
#endif

                // Determine source file
                if (filepathname.Length > 0)
                    sourcefile = filepathname;
                else
                    sourcefile = tempwad.Filename;

                // Copy lumps to buildwad
                General.WriteLogLine("Copying map lumps to temporary build file...");
                CopyLumpsByType(tempwad, TEMP_MAP_HEADER, buildwad, BUILD_MAP_HEADER, true, false, false, true);

                // Close buildwad
                buildwad.Dispose();

                // Does the nodebuilder require an output file?
                if (nodebuilder.HasSpecialOutputFile)
                {
                    // Make a temporary output file for the nodebuilder
                    tempfile2 = General.MakeTempFilename(compiler.Location);
                    General.WriteLogLine("Temporary output file: " + tempfile2);
                }
                else
                {
                    // Output file is same as input file
                    tempfile2 = tempfile1;
                }

                // Run the nodebuilder
                compiler.Parameters = nodebuilder.Parameters;
                compiler.InputFile = Path.GetFileName(tempfile1);
                compiler.OutputFile = Path.GetFileName(tempfile2);
                compiler.SourceFile = sourcefile;
                compiler.WorkingDirectory = Path.GetDirectoryName(tempfile1);
                if (compiler.Run())
                {
                    // Open the output file
                    try { buildwad = new WAD(tempfile2); }
                    catch (Exception e)
                    {
                        General.WriteLogLine(e.GetType().Name + " while reading build wad file: " + e.Message);
                        buildwad = null;
                    }

                    if (buildwad != null)
                    {
                        // Output lumps complete?
                        lumpscomplete = VerifyNodebuilderLumps(buildwad, BUILD_MAP_HEADER);
                    }

                    if (lumpscomplete)
                    {
                        // Copy nodebuilder lumps to temp file
                        General.WriteLogLine("Copying nodebuilder lumps to temporary file...");
                        CopyLumpsByType(buildwad, BUILD_MAP_HEADER, tempwad, TEMP_MAP_HEADER, false, false, true, false);
                    }
                    else
                    {
                        // Nodebuilder did not build the lumps!
                        if (failaswarning)
                            General.ShowWarningMessage("Unable to build the nodes: The nodebuilder failed to build the expected data structures.\nThe map will be saved without the nodes.", MessageBoxButtons.OK);
                        else
                            General.ShowErrorMessage("Unable to build the nodes: The nodebuilder failed to build the expected data structures.", MessageBoxButtons.OK);
                    }

                    // Done with the build wad
                    if (buildwad != null) buildwad.Dispose();
                }

                // Clean up
                compiler.Dispose();

                // Return result
                return lumpscomplete;
            }
        }

        // This verifies if the nodebuilder lumps exist in a WAD file
        private bool VerifyNodebuilderLumps(WAD wad, string mapheader)
        {
            bool lumpscomplete = false;

            // Find the map header in source
            int srcindex = wad.FindLumpIndex(mapheader);
            if (srcindex > -1)
            {
                // Go for all the map lump names
                lumpscomplete = true;
                foreach (DictionaryEntry ml in config.MapLumpNames)
                {
                    // Read lump settings from map config
                    bool lumpnodebuild = config.ReadSetting("maplumpnames." + ml.Key + ".nodebuild", false);
                    bool lumpallowempty = config.ReadSetting("maplumpnames." + ml.Key + ".allowempty", false);

                    // Check if this lump should exist
                    if (lumpnodebuild && !lumpallowempty)
                    {
                        // Find the lump in the source
                        if (wad.FindLump(ml.Key.ToString(), srcindex, srcindex + config.MapLumpNames.Count + 2) == null)
                        {
                            // Missing a lump!
                            lumpscomplete = false;
                            break;
                        }
                    }
                }
            }

            return lumpscomplete;
        }

        #endregion

        #region ================== Lumps

        // This returns a copy of the requested lump stream data
        // This is copied from the temp wad file and returns null when the lump is not found
        internal MemoryStream GetLumpData(string lumpname)
        {
            Lump l = tempwad.FindLump(lumpname);
            if (l != null)
            {
                l.Stream.Seek(0, SeekOrigin.Begin);
                return new MemoryStream(l.Stream.ReadAllBytes());
            }
            else
            {
                return null;
            }
        }

        // This writes a copy of the data to a lump in the temp file
        internal void SetLumpData(string lumpname, MemoryStream data)
        {
            int insertindex = tempwad.Lumps.Count;

            // Remove the lump if it already exists
            int li = tempwad.FindLumpIndex(lumpname);
            if (li > -1)
            {
                insertindex = li;
                tempwad.RemoveAt(li);
            }

            // Insert new lump
            Lump l = tempwad.Insert(lumpname, insertindex, (int)data.Length);
            l.Stream.Seek(0, SeekOrigin.Begin);
            data.WriteTo(l.Stream);

            IsChanged = true;
        }

        // This creates empty lumps for those required
        private void CreateRequiredLumps(WAD target, string mapname)
        {
            int headerindex, insertindex, targetindex;
            string lumpname;
            bool lumprequired;

            // Find the map header in target
            headerindex = target.FindLumpIndex(mapname);
            if (headerindex == -1)
            {
                // If this header doesnt exists in the target
                // then insert at the end of the target
                headerindex = target.Lumps.Count;
            }

            // Begin inserting at target header index
            insertindex = headerindex;

            // Go for all the map lump names
            foreach (DictionaryEntry ml in config.MapLumpNames)
            {
                // Read lump settings from map config
                lumprequired = config.ReadSetting("maplumpnames." + ml.Key + ".required", false);

                // Check if this lump is required
                if (lumprequired)
                {
                    // Get the lump name
                    lumpname = ml.Key.ToString();
                    if (lumpname == CONFIG_MAP_HEADER) lumpname = mapname;

                    // Check if the lump is missing at the target
                    targetindex = FindSpecificLump(target, lumpname, headerindex, mapname, config.MapLumpNames);
                    if (targetindex == -1)
                    {
                        // Determine target index
                        insertindex++;
                        if (insertindex > target.Lumps.Count) insertindex = target.Lumps.Count;

                        // Create new, emtpy lump
                        General.WriteLogLine(lumpname + " is required! Created empty lump.");
                        target.Insert(lumpname, insertindex, 0);
                    }
                    else
                    {
                        // Move insert index
                        insertindex = targetindex;
                    }
                }
            }
        }

        // This copies all lumps, except those of a specific map
        private void CopyAllLumpsExceptMap(WAD source, WAD target, string sourcemapname)
        {
            // Go for all lumps
            bool skipping = false;
            foreach (Lump srclump in source.Lumps)
            {
                // Check if we should stop skipping lumps here
                if (skipping && !config.MapLumpNames.Contains(srclump.Name))
                {
                    // Stop skipping
                    skipping = false;
                }

                // Check if we should start skipping lumps here
                if (!skipping && (srclump.Name == sourcemapname))
                {
                    // We have encountered the map header, start skipping!
                    skipping = true;
                }

                // Not skipping this lump?
                if (!skipping)
                {
                    // Copy lump over!
                    Lump tgtlump = target.Insert(srclump.Name, target.Lumps.Count, srclump.Length);
                    srclump.CopyTo(tgtlump);
                }
            }
        }

        // This copies specific map lumps from one WAD to another
        private void CopyLumpsByType(WAD source, string sourcemapname,
                                     WAD target, string targetmapname,
                                     bool copyrequired, bool copyblindcopy,
                                     bool copynodebuild, bool copyscript)
        {
            bool lumprequired, lumpblindcopy, lumpnodebuild;
            string lumpscript, srclumpname, tgtlumpname;
            int srcheaderindex, tgtheaderindex, targetindex, sourceindex, lumpindex;
            Lump lump, newlump;

            // Find the map header in target
            tgtheaderindex = target.FindLumpIndex(targetmapname);
            if (tgtheaderindex == -1)
            {
                // If this header doesnt exists in the target
                // then insert at the end of the target
                tgtheaderindex = target.Lumps.Count;
            }

            // Begin inserting at target header index
            targetindex = tgtheaderindex;

            // Find the map header in source
            srcheaderindex = source.FindLumpIndex(sourcemapname);
            if (srcheaderindex > -1)
            {
                // Copy the map header from source to target
                //newlump = target.Insert(targetmapname, tgtindex++, source.Lumps[srcindex].Length);
                //source.Lumps[srcindex].CopyTo(newlump);

                // Go for all the map lump names
                foreach (DictionaryEntry ml in config.MapLumpNames)
                {
                    // Read lump settings from map config
                    lumprequired = config.ReadSetting("maplumpnames." + ml.Key + ".required", false);
                    lumpblindcopy = config.ReadSetting("maplumpnames." + ml.Key + ".blindcopy", false);
                    lumpnodebuild = config.ReadSetting("maplumpnames." + ml.Key + ".nodebuild", false);
                    lumpscript = config.ReadSetting("maplumpnames." + ml.Key + ".script", "");

                    // Check if this lump should be copied
                    if ((lumprequired && copyrequired) || (lumpblindcopy && copyblindcopy) ||
                       (lumpnodebuild && copynodebuild) || ((lumpscript.Length != 0) && copyscript))
                    {
                        // Get the lump name
                        srclumpname = ml.Key.ToString();
                        tgtlumpname = ml.Key.ToString();
                        if (srclumpname == CONFIG_MAP_HEADER) srclumpname = sourcemapname;
                        if (tgtlumpname == CONFIG_MAP_HEADER) tgtlumpname = targetmapname;

                        // Find the lump in the source
                        sourceindex = FindSpecificLump(source, srclumpname, srcheaderindex, sourcemapname, config.MapLumpNames);
                        if (sourceindex > -1)
                        {
                            // Remove lump at target
                            lumpindex = RemoveSpecificLump(target, tgtlumpname, tgtheaderindex, targetmapname, config.MapLumpNames);

                            // Determine target index
                            // When original lump was found and removed then insert at that position
                            // otherwise insert after last insertion position
                            if (lumpindex > -1) targetindex = lumpindex; else targetindex++;
                            if (targetindex > target.Lumps.Count) targetindex = target.Lumps.Count;

                            // Copy the lump to the target
                            //General.WriteLogLine(srclumpname + " copying as " + tgtlumpname);
                            lump = source.Lumps[sourceindex];
                            newlump = target.Insert(tgtlumpname, targetindex, lump.Length);
                            lump.CopyTo(newlump);
                        }
                        else
                        {
                            // We don't want to bother the user with this. There are a lot of lumps in
                            // the game configs that are trivial and don't need to be found.
                            if (lumprequired)
                            {
                                General.ErrorLogger.Add(ErrorType.Warning, ml.Key.ToString() + " (required lump) should be read but was not found in the WAD file.");
                            }
                        }
                    }
                }
            }
        }

        // This finds a lump within the range of known lump names
        // Returns -1 when the lump cannot be found
        internal static int FindSpecificLump(WAD source, string lumpname, int mapheaderindex, string mapheadername, IDictionary maplumps)
        {
            // Use the configured map lump names to find the specific lump within range,
            // because when an unknown lump is met, this search must stop.

            // Go for all lumps in order to find the specified lump
            for (int i = 0; i < maplumps.Count + 1; i++)
            {
                // Still within bounds?
                if ((mapheaderindex + i) < source.Lumps.Count)
                {
                    // Check if this is a known lump name
                    if (maplumps.Contains(source.Lumps[mapheaderindex + i].Name) ||
                       (maplumps.Contains(CONFIG_MAP_HEADER) && (source.Lumps[mapheaderindex + i].Name == mapheadername)))
                    {
                        // Is this the lump we are looking for?
                        if (source.Lumps[mapheaderindex + i].Name == lumpname)
                        {
                            // Return this index
                            return mapheaderindex + i;
                        }
                    }
                    else
                    {
                        // Unknown lump hit, abort search
                        break;
                    }
                }
            }

            // Nothing found
            return -1;
        }

        // This removes a specific lump and returns the position where the lump was removed
        // Returns -1 when the lump could not be found
        internal static int RemoveSpecificLump(WAD source, string lumpname, int mapheaderindex, string mapheadername, IDictionary maplumps)
        {
            int lumpindex;

            // Find the specific lump index
            lumpindex = FindSpecificLump(source, lumpname, mapheaderindex, mapheadername, maplumps);
            if (lumpindex > -1)
            {
                // Remove this lump
                //General.WriteLogLine(lumpname + " removed");
                source.RemoveAt(lumpindex);
            }
            else
            {
                // Lump not found
                //General.ErrorLogger.Add(ErrorType.Warning, lumpname + " should be removed but was not found!");
            }

            // Return result
            return lumpindex;
        }

        #endregion

        #region ================== Selection Groups

        // This adds selection to a group
        private void AddSelectionToGroup(int groupindex)
        {
            General.Interface.SetCursor(Cursors.WaitCursor);

            // Make undo
            undoredo.CreateUndo("Assign to group " + groupindex);

            // Make selection
            map.AddSelectionToGroup(0x01 << groupindex);

            General.Interface.DisplayStatus(StatusType.Action, "Assigned selection to group " + groupindex);
            General.Interface.SetCursor(Cursors.Default);
        }

        // This selects a group
        private void SelectGroup(int groupindex)
        {
            // Select
            int groupmask = 0x01 << groupindex;
            map.SelectVerticesByGroup(groupmask);
            map.SelectLinedefsByGroup(groupmask);
            map.SelectSectorsByGroup(groupmask);
            map.SelectThingsByGroup(groupmask);

            // Redraw to show selection
            General.Interface.DisplayStatus(StatusType.Action, "Selected group " + groupindex);
            General.Interface.RedrawDisplay();
        }

        // Select actions
        [BeginAction("selectgroup1")] internal void SelectGroup1() { SelectGroup(0); }
        [BeginAction("selectgroup2")] internal void SelectGroup2() { SelectGroup(1); }
        [BeginAction("selectgroup3")] internal void SelectGroup3() { SelectGroup(2); }
        [BeginAction("selectgroup4")] internal void SelectGroup4() { SelectGroup(3); }
        [BeginAction("selectgroup5")] internal void SelectGroup5() { SelectGroup(4); }
        [BeginAction("selectgroup6")] internal void SelectGroup6() { SelectGroup(5); }
        [BeginAction("selectgroup7")] internal void SelectGroup7() { SelectGroup(6); }
        [BeginAction("selectgroup8")] internal void SelectGroup8() { SelectGroup(7); }
        [BeginAction("selectgroup9")] internal void SelectGroup9() { SelectGroup(8); }
        [BeginAction("selectgroup10")] internal void SelectGroup10() { SelectGroup(9); }

        // Assign actions
        [BeginAction("assigngroup1")] internal void AssignGroup1() { AddSelectionToGroup(0); }
        [BeginAction("assigngroup2")] internal void AssignGroup2() { AddSelectionToGroup(1); }
        [BeginAction("assigngroup3")] internal void AssignGroup3() { AddSelectionToGroup(2); }
        [BeginAction("assigngroup4")] internal void AssignGroup4() { AddSelectionToGroup(3); }
        [BeginAction("assigngroup5")] internal void AssignGroup5() { AddSelectionToGroup(4); }
        [BeginAction("assigngroup6")] internal void AssignGroup6() { AddSelectionToGroup(5); }
        [BeginAction("assigngroup7")] internal void AssignGroup7() { AddSelectionToGroup(6); }
        [BeginAction("assigngroup8")] internal void AssignGroup8() { AddSelectionToGroup(7); }
        [BeginAction("assigngroup9")] internal void AssignGroup9() { AddSelectionToGroup(8); }
        [BeginAction("assigngroup10")] internal void AssignGroup10() { AddSelectionToGroup(9); }

        #endregion

        #region ================== Script Editing

        // Show the script editor
        [BeginAction("openscripteditor")]
        internal void ShowScriptEditor()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (scriptwindow == null)
            {
                // Load the window

                // DON'T USE
                /*if (General.Map.FormatInterface.InDoom64Mode)   // villsa
                {
                    MapInfoForm mapinfowindow = new MapInfoForm();
                    DialogResult result = mapinfowindow.ShowDialog(MainForm.ActiveForm);
                    mapinfowindow.Dispose();
                }
                else*/
                scriptwindow = new ScriptEditorForm();
            }

            //if (!General.Map.FormatInterface.InDoom64Mode)  // villsa
            //{
            // Window not yet visible?
            if (!scriptwindow.Visible)
            {
                // Show the window
                if (General.Settings.ScriptOnTop)
                {
                    if (scriptwindow.Visible && (scriptwindow.Owner == null)) scriptwindow.Hide();
                    scriptwindow.Show(General.MainWindow);
                }
                else
                {
                    if (scriptwindow.Visible && (scriptwindow.Owner != null)) scriptwindow.Hide();
                    scriptwindow.Show();
                }
            }
            scriptwindow.Activate();
            scriptwindow.Focus();
            //}
            Cursor.Current = Cursors.Default;
        }

        // This asks the user to save changes in script files
        // Returns false when cancelled by the user
        internal bool AskSaveScriptChanges()
        {
            // Window open?
            if (scriptwindow != null)
            {
                // Ask to save changes
                // This also saves implicitly
                return scriptwindow.AskSaveAll();
            }
            else
            {
                // No problems
                return true;
            }
        }

        // This applies the changed status for internal scripts
        internal void ApplyScriptChanged()
        {
            // Remember if lumps are changed
            scriptschanged |= scriptwindow.Editor.CheckImplicitChanges();
        }

        // Close the script editor
        // Specify true for the closing parameter when
        // the window is already in the closing process
        internal void CloseScriptEditor(bool closing)
        {
            if (scriptwindow != null)
            {
                if (!scriptwindow.IsDisposed)
                {
                    // Remember what files were open
                    scriptwindow.Editor.WriteOpenFilesToConfiguration();

                    // Close now
                    if (!closing) scriptwindow.Close();
                }

                // Done
                scriptwindow = null;
            }
        }

        // This checks if the scripts are changed
        internal bool CheckScriptChanged()
        {
            if (scriptwindow != null)
            {
                // Check if scripts are changed			
                return scriptschanged || scriptwindow.Editor.CheckImplicitChanges();
            }
            else
            {
                // Check if scripts are changed			
                return scriptschanged;
            }
        }

        // This compiles all lumps that require compiling and stores the results
        // Returns true when our code worked properly (even when the compiler returned errors)
        private bool CompileScriptLumps()
        {
            bool success = true;
            errors.Clear();

            // Go for all the map lumps
            foreach (MapLumpInfo lumpinfo in config.MapLumps.Values)
            {
                // Is this a script lump?
                if (lumpinfo.script != null)
                {
                    // Compile it now
                    success &= CompileLump(lumpinfo.name, false);
                }
            }
            return success;
        }

        // This compiles a script lump and returns any errors that may have occurred
        // Returns true when our code worked properly (even when the compiler returned errors)
        internal bool CompileLump(string lumpname, bool clearerrors)
        {
            string inputfile, outputfile, sourcefile;
            Compiler compiler;
            byte[] filedata;
            string reallumpname = lumpname;

            // Find the lump
            if (lumpname == CONFIG_MAP_HEADER) reallumpname = TEMP_MAP_HEADER;
            Lump lump = tempwad.FindLump(reallumpname);
            if (lump == null) throw new Exception("No such lump in temporary wad file '" + reallumpname + "'.");

            // Determine source file
            if (filepathname.Length > 0)
                sourcefile = filepathname;
            else
                sourcefile = tempwad.Filename;

            // New list of errors
            if (clearerrors) errors.Clear();

            // Determine the script configuration to use
            ScriptConfiguration scriptconfig = config.MapLumps[lumpname].script;
            if (scriptconfig.Compiler != null)
            {
                try
                {
                    // Initialize compiler
                    compiler = scriptconfig.Compiler.Create();
                }
                catch (Exception e)
                {
                    // Fail
                    errors.Add(new CompilerError("Unable to initialize compiler. " + e.GetType().Name + ": " + e.Message));
                    return false;
                }

                try
                {
                    // Write lump data to temp script file in compiler's temp directory
                    inputfile = General.MakeTempFilename(compiler.Location, "tmp");
                    lump.Stream.Seek(0, SeekOrigin.Begin);
                    BinaryReader reader = new BinaryReader(lump.Stream);
                    File.WriteAllBytes(inputfile, reader.ReadBytes((int)lump.Stream.Length));
                }
                catch (Exception e)
                {
                    // Fail
                    compiler.Dispose();
                    errors.Add(new CompilerError("Unable to write script to working file. " + e.GetType().Name + ": " + e.Message));
                    return false;
                }

                // Make random output filename
                outputfile = General.MakeTempFilename(compiler.Location, "tmp");

                // Run compiler
                compiler.Parameters = scriptconfig.Parameters;
                compiler.InputFile = Path.GetFileName(inputfile);
                compiler.OutputFile = Path.GetFileName(outputfile);
                compiler.SourceFile = sourcefile;
                compiler.WorkingDirectory = Path.GetDirectoryName(inputfile);
                if (compiler.Run())
                {
                    // Process errors
                    foreach (CompilerError e in compiler.Errors)
                    {
                        CompilerError newerror = e;

                        // If the error's filename equals our temporary file,
                        // use the lump name instead and prefix it with ?
                        if (string.Compare(e.filename, inputfile, true) == 0)
                            newerror.filename = "?" + reallumpname;

                        errors.Add(newerror);
                    }

                    // No errors?
                    if (compiler.Errors.Length == 0)
                    {
                        // Output file exists?
                        if (File.Exists(outputfile))
                        {
                            // Copy output file data into a lump?
                            if (!string.IsNullOrEmpty(scriptconfig.ResultLump))
                            {
                                // Do that now then
                                try
                                {
                                    filedata = File.ReadAllBytes(outputfile);
                                }
                                catch (Exception e)
                                {
                                    // Fail
                                    compiler.Dispose();
                                    errors.Add(new CompilerError("Unable to read compiler output file. " + e.GetType().Name + ": " + e.Message));
                                    return false;
                                }

                                // Store data
                                MemoryStream stream = new MemoryStream(filedata);
                                SetLumpData(scriptconfig.ResultLump, stream);
                            }
                        }
                    }

                    // Clean up
                    compiler.Dispose();

                    // Done
                    return true;
                }
                else
                {
                    // Fail
                    compiler.Dispose();
                    errors = null;
                    return false;
                }
            }
            else
            {
                // No compiler to run for this script type
                return true;
            }
        }

        // This clears all compiler errors
        internal void ClearCompilerErrors()
        {
            errors.Clear();
        }

        #endregion

        #region ================== Methods

        // This updates everything after the configuration or settings have been changed
        internal void UpdateConfiguration()
        {
            // Update map
            map.UpdateConfiguration();

            // Update settings
            renderer3d.CreateProjection();

            // Things filters
            General.MainWindow.UpdateThingsFilters();
        }

        // This changes thing filter
        public void ChangeThingFilter(ThingsFilter newfilter)
        {
            // We have a special filter for null
            if (newfilter == null) newfilter = new NullThingsFilter();

            // Deactivate old filter
            if (thingsfilter != null) thingsfilter.Deactivate();

            // Change
            thingsfilter = newfilter;

            // Activate filter
            thingsfilter.Activate();

            // Update interface
            General.MainWindow.ReflectThingsFilter();

            // Redraw
            General.MainWindow.RedrawDisplay();
        }

        // This sets a new mapset for editing
        internal void ChangeMapSet(MapSet newmap)
        {
            // Let the plugin and editing mode know
            General.Plugins.OnMapSetChangeBegin();
            if (General.Editing.Mode != null) General.Editing.Mode.OnMapSetChangeBegin();
            this.visualcamera.Sector = null;

            // Can't have a selection in an old map set
            map.ClearAllSelected();

            // Reset surfaces
            renderer2d.Surfaces.Reset();

            // Apply
            map.Dispose();
            map = newmap;
            map.UpdateConfiguration();
            map.SnapAllToAccuracy();
            map.Update();
            thingsfilter.Update();

            // Let the plugin and editing mode know
            General.Plugins.OnMapSetChangeEnd();
            if (General.Editing.Mode != null) General.Editing.Mode.OnMapSetChangeEnd();
        }

        // This reloads resources
        [BeginAction("reloadresources")]
        internal void DoReloadResource()
        {
            // Set this to false so we can see if errors are added
            General.ErrorLogger.IsErrorAdded = false;

            ReloadResources();

            if (General.ErrorLogger.IsErrorAdded)
            {
                // Show any errors if preferred
                General.MainWindow.DisplayStatus(StatusType.Warning, "There were errors during resources loading!");
                if (General.Settings.ShowErrorsWindow) General.MainWindow.ShowErrors();
            }
            else
                General.MainWindow.DisplayReady();

        }
        internal void ReloadResources()
        {
            DataLocation maplocation;
            StatusInfo oldstatus;
            Cursor oldcursor;

            // Keep old display info
            oldstatus = General.MainWindow.Status;
            oldcursor = Cursor.Current;

            // Show status
            General.MainWindow.DisplayStatus(StatusType.Busy, "Reloading data resources...");
            Cursor.Current = Cursors.WaitCursor;

            // Clean up
            data.Dispose();
            data = null;
            config = null;
            configinfo = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Reload game configuration
            General.WriteLogLine("Reloading game configuration...");
            configinfo = General.GetConfigurationInfo(options.ConfigFile);
            config = new GameConfiguration(General.LoadGameConfiguration(options.ConfigFile));
            General.Editing.UpdateCurrentEditModes();

            // Reload data resources
            General.WriteLogLine("Reloading data resources...");
            data = new DataManager();
            if (!string.IsNullOrEmpty(filepathname))
            {
                maplocation = new DataLocation(DataLocation.RESOURCE_WAD, filepathname, false, false, false);
                data.Load(configinfo.Resources, options.Resources, maplocation);
            }
            else
            {
                data.Load(configinfo.Resources, options.Resources);
            }

            // Apply new settings to map elements
            map.UpdateConfiguration();

            // Re-link the background image
            grid.LinkBackground();

            // Inform all plugins that the resources are reloaded
            General.Plugins.ReloadResources();

            // Inform editing mode that the resources are reloaded
            if (General.Editing.Mode != null) General.Editing.Mode.OnReloadResources();

            // Reset status
            General.MainWindow.DisplayStatus(oldstatus);
            Cursor.Current = oldcursor;
        }

        // Game Configuration action
        [BeginAction("mapoptions")]
        internal void ShowMapOptions()
        {
            // Cancel volatile mode, if any
            General.Editing.DisengageVolatileMode();

            // Show map options dialog
            MapOptionsForm optionsform = new MapOptionsForm(options);
            if (optionsform.ShowDialog(General.MainWindow) == DialogResult.OK)
            {
                // Update interface
                General.MainWindow.UpdateInterface();

                // Stop data manager
                data.Dispose();

                // Apply new options
                this.options = optionsform.Options;

                // Load new game configuration
                General.WriteLogLine("Loading game configuration...");
                configinfo = General.GetConfigurationInfo(options.ConfigFile);
                config = new GameConfiguration(General.LoadGameConfiguration(options.ConfigFile));
                configinfo.ApplyDefaults(config);
                General.Editing.UpdateCurrentEditModes();

                // Setup new map format IO
                General.WriteLogLine("Initializing map format interface " + config.FormatInterface + "...");
                io = MapSetIO.Create(config.FormatInterface, tempwad, this);

                // Create required lumps if they don't exist yet
                CreateRequiredLumps(tempwad, TEMP_MAP_HEADER);

                // Let the plugins know
                General.Plugins.MapReconfigure();

                // Update interface
                General.MainWindow.SetupInterface();
                General.MainWindow.UpdateThingsFilters();
                General.MainWindow.UpdateInterface();

                // Reload resources
                ReloadResources();

                // Done
                General.MainWindow.DisplayReady();
            }

            // Done
            optionsform.Dispose();
        }

        // This shows the things filters setup
        [BeginAction("thingsfilterssetup")]
        internal void ShowThingsFiltersSetup()
        {
            // Show things filter dialog
            ThingsFiltersForm f = new ThingsFiltersForm();
            f.ShowDialog(General.MainWindow);
            f.Dispose();
            General.MainWindow.UpdateThingsFilters();
        }

        // This returns true is the given type matches
        public bool IsType(Type t)
        {
            return io.GetType().Equals(t);
        }

        #endregion
    }
}
