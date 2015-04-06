using Dev4s.Helpers;
using NUnit.Framework;

namespace Dev4s.HelpersTests
{
	//TODO: Clean Tests - Arrange, Act, Assert
	[TestFixture]
	public class SettingsTests
	{
		[SetUp]
		public void TestsSetUp()
		{
			Settings.Load();
		}
		
		[Test]
		public void DoesSettingsTestClassPropertiesHasGotDefaultValues()
		{
			var attrForStringName = TestsExtensions.GetAttributesFromProperties(typeof (SettingsTestClass), "StringName")[0] 
									as SettingsDefaultValueAttribute;
			var attrForIntName = TestsExtensions.GetAttributesFromProperties(typeof (SettingsTestClass), "IntName")[0] 
								 as SettingsDefaultValueAttribute;

			Assert.That(attrForStringName, Is.TypeOf(typeof (SettingsDefaultValueAttribute)));
			Assert.That(attrForIntName, Is.TypeOf(typeof (SettingsDefaultValueAttribute)));

			Assert.That(attrForStringName.Value, Is.EqualTo("test_string"));
			Assert.That(attrForIntName.Value, Is.EqualTo(100));
		}

		[Test]
		public void CheckingIfPropertiesWithSettingsDefaultValuetAttributeReturnDefaultValues()
		{
			Assert.That(SettingsTestClass.StringName, Is.EqualTo("test_string"));
			Assert.That(SettingsTestClass.IntName, Is.EqualTo(100));
		}

		[Test]
		public void CheckingIfPropertiesWithoutSettingsDefaultValuetAttributeReturnNull()
		{
			Assert.That(SettingsTestClass.IntNameWithoutDefaultValue, Is.EqualTo(0));
			Assert.That(SettingsTestClass.StringNameWithoutDefaultValue, Is.Null);
		}

		[Test]
		public void CheckIfValueHaveChangedWhenPropertyHaveSettingsDefaultValueAttribute()
		{
			SettingsTestClass.IntName = 200;
			SettingsTestClass.StringName = "changed_string";
			
			Assert.That(SettingsTestClass.IntName, Is.EqualTo(200));
			Assert.That(SettingsTestClass.StringName, Is.EqualTo("changed_string"));
		}

		[Test]
		public void CheckIfValueHaveChangedWhenPropertyDoesNotHaveSettingsDefaultValueAttribute()
		{
			SettingsTestClass.IntNameWithoutDefaultValue = 200;
			SettingsTestClass.StringNameWithoutDefaultValue = "changed_string";

			Assert.That(SettingsTestClass.IntNameWithoutDefaultValue, Is.EqualTo(200));
			Assert.That(SettingsTestClass.StringNameWithoutDefaultValue, Is.EqualTo("changed_string"));
		}

		[Test, Ignore]
		public void CheckIfSettingsClassIsSavingSettingsToDefaultXmlFile()
		{
			
		}

		[Test, Ignore]
		public void CheckIfSettingsClassIsLoadingSettingsFromXmlFileAfterTheSettingsWereChanged()
		{
			
		}

		[Test, Ignore]
		public void TestingIfSettingsClassIsAssigningTheValuesInFormForSpecificNames()
		{
			
		}
	}
}