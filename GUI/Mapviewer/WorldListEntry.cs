using System;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using MCDek;
using MCLawl;


namespace MCDek.Gui.MapEditor
{
    sealed class WorldListEntry {
        public const string DefaultClassOption = "(everyone)";
        Level cachedMapHeader;
        internal bool loadingFailed;

        public WorldListEntry() { }

        public WorldListEntry( WorldListEntry original ) {
            name = original.Name;
            Hidden = original.Hidden;
            AccessPermission = original.AccessPermission;
            BuildPermission = original.BuildPermission;
        }

        public WorldListEntry( XElement el ) {
            XAttribute temp;

            if( (temp = el.Attribute( "name" )) == null ) {
                throw new Exception( "WorldListEntity: Cannot parse XML: Unnamed worlds are not allowed." );
            }
            if( !Player.ValidName( temp.Value ) ) {
                throw new Exception( "WorldListEntity: Cannot parse XML: Invalid world name skipped \"" + temp.Value + "\"." );
            }
            name = temp.Value;

            if( (temp = el.Attribute( "hidden" )) != null ) {
                bool hidden;
                if( bool.TryParse( temp.Value, out hidden ) ) {
                    Hidden = hidden;
                } else {
                    throw new Exception( "WorldListEntity: Cannot parse XML: Invalid value for \"hidden\" attribute." );
                }
            } else {
                Hidden = false;
            }

            /* TODO: Make this work or soemthing
            if( (temp = el.Attribute( "access" )) != null ) {
                accessClass = ClassList.ParseClass( temp.Value );
                if( accessClass == null ) {
                    throw new Exception( "WorldListEntity: Cannot parse XML: Unrecognized class specified for \"access\" permission." );
                }
            }

            if( (temp = el.Attribute( "build" )) != null ) {
                buildClass = ClassList.ParseClass( temp.Value );
                if( buildClass == null ) {
                    throw new Exception( "WorldListEntity: Cannot parse XML: Unrecognized class specified for \"build\" permission." );
                }
            }*/
        }

        internal string name;
        public string Name {
            get {
                return name;
            }
            set {
                if( !Player.ValidName( value ) ) {
                    throw new FormatException( "Invalid world name" );
                }
                else if (value != name && Server.LevelExists(value))
                {
                    throw new FormatException( "Duplicate world names are not allowed." );
                } else {
                    string oldName = name;
                    name = value;
                    if( File.Exists( "maps/" + name + ".lvl" ) && value != name ) {
                        File.Move( "maps/" + name + ".lvl", value + ".lvl" );
                    }
                    // TODO: See if we need this
                    //ConfigUI.HandleWorldRename( oldName, value );
                }
            }
        }

        public string Description {
            get {
                if( cachedMapHeader == null && !loadingFailed ) {
                    cachedMapHeader = Level.LoadHeaderOnly( "maps/" + name + ".lvl" );
                    if( cachedMapHeader == null ) {
                        loadingFailed = true;
                    }
                }
                if( loadingFailed ) {
                    return "(cannot load file)";
                } else {
                    return String.Format( "{0} × {1} × {2}", cachedMapHeader.width, cachedMapHeader.depth, cachedMapHeader.height );
                }
            }
        }

        public bool Hidden { get; set; }

        internal LevelPermission accessClass;
        public string AccessPermission {
            get {
                if( accessClass != null ) {
                    // TODO: Figure out what this does and remove my kludge below
                    //return accessClass.ToComboBoxOption();
                    return DefaultClassOption;
                } else {
                    return DefaultClassOption;
                }
            }
            set {
                // TODO: Figure out what this does and remove my kludge below
                /*
                foreach( PlayerClass pc in ClassList.classesByIndex ) {
                    if( pc.ToComboBoxOption() == value ) {
                        accessClass = pc;
                        return;
                    }
                }*/
                accessClass = LevelPermission.Null;
            }
        }

        internal LevelPermission buildClass;
        public string BuildPermission {
            get {
                if( buildClass != null ) {
                    // TODO: Figure out what this does and remove my kludge below
                    //return buildClass.ToComboBoxOption();
                    return DefaultClassOption;
                } else {
                    return DefaultClassOption;
                }
            }
            set {
                // TODO: Figure out what this does and remove my kludge below
                /*
                foreach( PlayerClass pc in ClassList.classesByIndex ) {
                    if( pc.ToComboBoxOption() == value ) {
                        buildClass = pc;
                        return;
                    }
                }
                buildClass = null;
                */
                buildClass = LevelPermission.Null;
            }
        }

        internal XElement Serialize() {
            XElement element = new XElement( "World" );
            element.Add( new XAttribute( "name", Name ) );
            element.Add( new XAttribute( "hidden", Hidden ) );
            /*
            if( accessClass != null ) element.Add( new XAttribute( "access", accessClass ) );
            if( buildClass != null ) element.Add( new XAttribute( "build", buildClass ) );
             */
            return element;
        }
    }
}