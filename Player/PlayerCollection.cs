using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using MCDek;

namespace MCLawl
{

    public class PlayerCollection : List<Player>, ITypedList
    {
        protected IPlayerViewBuilder _viewBuilder;

        public PlayerCollection(IPlayerViewBuilder viewBuilder)
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
            return ""; // was used by 1.1 datagrid
        }

        #endregion
    }

    public interface IPlayerViewBuilder
    {
        PropertyDescriptorCollection GetView();
    }

    public class PlayerListView : IPlayerViewBuilder
    {
        public PropertyDescriptorCollection GetView()
        {
            List<PropertyDescriptor> props = new List<PropertyDescriptor>();
            /*PlayerMethodDelegate del = delegate(Player p)
{
return p.name;
};*/
            props.Add(new PlayerMethodDescriptor("Name", p => p.name, typeof(string)));

            props.Add(new PlayerMethodDescriptor("Map", p => p.level.name, typeof(string)));

            props.Add(new PlayerMethodDescriptor("Rank", p => p.group.name, typeof(string)));

            props.Add(new PlayerMethodDescriptor("Status", p =>
            {
                if (p.hidden)
                    return "hidden";
                if (Server.afkset.Contains(p.name))
                    return "afk";
                return "active";
            }, typeof(string)));

            PropertyDescriptor[] propArray = new PropertyDescriptor[props.Count];
            props.CopyTo(propArray);
            return new PropertyDescriptorCollection(propArray);
        }
    }


    public delegate object PlayerMethodDelegate(Player player);

    public class PlayerMethodDescriptor : PropertyDescriptor
    {
        protected PlayerMethodDelegate _method;
        protected Type _methodReturnType;

        public PlayerMethodDescriptor(string name, PlayerMethodDelegate method,
         Type methodReturnType)
            : base(name, null)
        {
            _method = method;
            _methodReturnType = methodReturnType;
        }

        public override object GetValue(object component)
        {
            return _method((Player)component);
        }

        public override Type ComponentType
        {
            get { return typeof(Player); }
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


