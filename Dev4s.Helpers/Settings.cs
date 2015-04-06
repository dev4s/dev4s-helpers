using System;
using System.Linq;
using System.Reflection;

namespace Dev4s.Helpers
{
	//TODO: Thinking about Changing this to: QuickSettings
	public static class Settings
	{
		private static bool _xmlSettingsExists;

		public static void Load()
		{
			//Find class which have SettingsAttribute applied
			var classesWithSettingsAttribute = FindClassWithSettingsAttribute(Assembly.GetCallingAssembly());

			//Load default Values for properties (if they have SettingsDefaultValueAttribute)
			LoadDefaultValues(classesWithSettingsAttribute);
		}

		private static Type FindClassWithSettingsAttribute(Assembly assembly)
		{
			//get all classes from specific assembly
			var types = assembly.GetTypes();

			//return classes which have SettingsAttribute
			//we are not taking inherited classes
			return types.SingleOrDefault(type => type.GetCustomAttributes(typeof(SettingsAttribute), false).Length > 0);
		}

		private static void LoadDefaultValues(Type classWithSettingsAttribute)
		{
			//get all properties from specific class
			var classProperties = classWithSettingsAttribute.GetProperties();

			//checking class properties for SettingsDefaultValueAttribute
			foreach (var classProperty in classProperties)
			{
				//if xml file with settings exists it reads all data from settings file
				if (_xmlSettingsExists)
				{
					//TODO: reading from XML file
				}
				else
				{
					SettingsDefaultValueAttribute classPropertyValue;
					try
					{
						//try to convert the property as SettingsDefaultValueAttribute - we will be using its value
						//for setting the property
						classPropertyValue = classProperty.GetCustomAttributes(typeof (SettingsDefaultValueAttribute), false)[0]
						                     as SettingsDefaultValueAttribute;
					}
					catch (Exception)
					{
						//reset values in properties for those which don't have a SettingsDefaultValueAttribute
						PropertyResetValueToDefault(classProperty);
						continue;
					}

					//we are checking if we can write the value for property
					if (classProperty.CanWrite)
					{
						//value setting
						if (classPropertyValue != null) 
							//even if we run the SetValue method on selected property we need to provide
							//the property name for value setting
							classProperty.SetValue(classProperty, classPropertyValue.Value, null);
					}
				}
			}
		}

		//method resets all properties which don't have a SettingsDefaultValueAttribute
		private static void PropertyResetValueToDefault(PropertyInfo property)
		{
			//TODO: do for more properties types
			switch (property.PropertyType.Name)
			{
				case "String":
					property.SetValue(property, null, null);
					break;

				case "Int32":
					property.SetValue(property, 0, null);
					break;
			}
		}
	}
}