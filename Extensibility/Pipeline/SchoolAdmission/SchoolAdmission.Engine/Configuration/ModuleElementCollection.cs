using System.Configuration;

namespace SchoolAdmission.Engine.Configuration
{
    [ConfigurationCollection(typeof(ModuleElement))]
    public class ModuleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ModuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ModuleElement)element).Name;
        }

        internal ModuleElement GetByName(string name)
        {
            ModuleElement module = null;
            foreach(ModuleElement element in this)
            {
                if (element.Name == name)
                {
                    module = element;
                    break;
                }
            }

            return module;
        }

        internal ModuleElement this[int index]
        {
            get
            {
                return this[index];
            }
        }
    }
}
