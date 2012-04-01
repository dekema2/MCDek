using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using MCDek;

namespace MCLawl
{

    public class LevelCollection : List<Level>, ITypedList
    {
        protected ILevelViewBuilder _viewBuilder;

        public LevelCollection(ILevelViewBuilder viewBuilder)
        {
            _viewBuilder = viewBuilder;
        }

        #region ITypedList Members

        protected PropertyDescriptorCollection _props;

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (_props == null)
            {
                _props = _viewBuilder.GetView();
            }
            return _props;
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }

        #endregion
    }

    public interface ILevelViewBuilder
    {
        PropertyDescriptorCollection GetView();
    }

    public class LevelListView : ILevelViewBuilder
    {
        public PropertyDescriptorCollection GetView()
        {
            List<PropertyDescriptor> props = new List<PropertyDescriptor>();
            LevelMethodDelegate del = l => l.name;
            props.Add(new LevelMethodDescriptor("Name", del, typeof(string)));

            del = l => l.players.Count;
            props.Add(new LevelMethodDescriptor("Players", del, typeof(int)));

            del = l => l.physics;
            props.Add(new LevelMethodDescriptor("Physics", del, typeof(int)));

            del = delegate(Level l)
            {
                Group grp = Group.GroupList.Find(g => g.Permission == l.permissionvisit);
                return grp == null ? l.permissionvisit.ToString() : grp.name;
            };
            props.Add(new LevelMethodDescriptor("PerVisit", del, typeof(string)));

            del = delegate(Level l)
            {
                Group grp = Group.GroupList.Find(g => g.Permission == l.permissionbuild);
                return grp == null ? l.permissionbuild.ToString() : grp.name;
            };
            props.Add(new LevelMethodDescriptor("PerBuild", del, typeof(string)));

            PropertyDescriptor[] propArray = new PropertyDescriptor[props.Count];
            props.CopyTo(propArray);
            return new PropertyDescriptorCollection(propArray);
        }
    }

    public class LevelListViewForTab : ILevelViewBuilder
    {
        public PropertyDescriptorCollection GetView()
        {
            List<PropertyDescriptor> props = new List<PropertyDescriptor>();
            LevelMethodDelegate del = l => l.name;
            props.Add(new LevelMethodDescriptor("Name", del, typeof(string)));

            del = l => l.players.Count;
            props.Add(new LevelMethodDescriptor("Players", del, typeof(int)));

            del = l => l.physics;
            props.Add(new LevelMethodDescriptor("Physics", del, typeof(int)));

            del = l => l.motd;
            props.Add(new LevelMethodDescriptor("MOTD", del, typeof(string)));

            del = l => l.GrassGrow;
            props.Add(new LevelMethodDescriptor("Grass", del, typeof(bool)));

            del = l => l.Killer;
            props.Add(new LevelMethodDescriptor("Killer-Blocks", del, typeof(bool)));

            del = l => l.worldChat;
            props.Add(new LevelMethodDescriptor("World-Chat", del, typeof(bool)));

            del = l => l.Death;
            props.Add(new LevelMethodDescriptor("Death", del, typeof(bool)));

            del = l => l.finite;
            props.Add(new LevelMethodDescriptor("Finite", del, typeof(bool)));


            del = l => l.edgeWater;
            props.Add(new LevelMethodDescriptor("Edge-Water", del, typeof(bool)));

            del = l => l.ai ? "Hunt" : "Flee";
            props.Add(new LevelMethodDescriptor("AI", del, typeof(string)));

            del = l => l.drown;
            props.Add(new LevelMethodDescriptor("Drown", del, typeof(int)));

            del = l => l.fall;
            props.Add(new LevelMethodDescriptor("Fall", del, typeof(int)));


            del = l => l.unload;
            props.Add(new LevelMethodDescriptor("Unload Empty", del, typeof(bool)));

            del =
                l =>
                (File.Exists("text/autoload.txt") &&
                 (File.ReadAllLines("text/autoload.txt").Contains(l.name) ||
                  File.ReadAllLines("text/autoload.txt").Contains(l.name.ToLower())));
            props.Add(new LevelMethodDescriptor("Autoload", del, typeof(bool)));

            del = delegate(Level l)
            {
                Group grp = Group.GroupList.Find(g => g.Permission == l.permissionvisit);
                return grp == null ? l.permissionvisit.ToString() : grp.name;
            };
            props.Add(new LevelMethodDescriptor("PerVisit", del, typeof(string)));

            del = delegate(Level l)
            {
                Group grp = Group.GroupList.Find(g => g.Permission == l.permissionbuild);
                return grp == null ? l.permissionbuild.ToString() : grp.name;
            };
            props.Add(new LevelMethodDescriptor("PerBuild", del, typeof(string)));

            PropertyDescriptor[] propArray = new PropertyDescriptor[props.Count];
            props.CopyTo(propArray);
            return new PropertyDescriptorCollection(propArray);


        }
    }

    public delegate object LevelMethodDelegate(Level l);

    public class LevelMethodDescriptor : PropertyDescriptor
    {
        protected LevelMethodDelegate _method;
        protected Type _methodReturnType;

        public LevelMethodDescriptor(string name, LevelMethodDelegate method,
         Type methodReturnType)
            : base(name, null)
        {
            _method = method;
            _methodReturnType = methodReturnType;
        }

        public override object GetValue(object component)
        {
            Level l = (Level)component;
            return _method(l);
        }

        public override Type ComponentType
        {
            get { return typeof(Level); }
        }

        public override Type PropertyType
        {
            get { return _methodReturnType; }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component) { }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override void SetValue(object component, object value) { }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}