using SparkValueBackend.Models;
using SparkValueBackend.Models.Components;
using SparkValueBackend.ViewModels;
using SparkValueBackend.Services;
using SparkValueBackend.Stores;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.ComponentModel;

namespace SparkValueTestingFramework
{
    public class Tests
    {
        #region Component Testing Constants
        private const double TestVoltage = 5.0;
        private const double TestCurrent = 1.0;

        private const double TestMixedVoltage = 1.38;
        private const double TestMixedCurrent = -0.005;

        private const double StandardCapacitanceValue = 500;
        private const double StandardResistenceValue = 5000;
        #endregion


        [SetUp]
        public void Setup()
        {

        }

        #region Model Testing

        #region Wire Model Tests

        #endregion

        #region Component Model Tests
        /// <summary>
        /// Tests a component model's methods to make sure they can handle a variety of inputs.
        /// Can it handle real positive numbers?
        /// Can it handle real negative numbers?
        /// Can it handle mixed numbers?
        /// Can it handle zeros?
        /// </summary>

        #region Basic Component
        [Test]
        public void BasicComponentCreate()
        {
            BasicComponentModel component = new BasicComponentModel("Component Name", "Component Description", "\\Images\\diode.png");
            Assert.IsNotNull(component, "Failed to create new BasicComponentModel!");
        }

        [TestCase(TestVoltage, TestCurrent, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, "mixed numbers")]
        [TestCase(0, 0, "zeros")]
        public void BasicComponentOutput(double inputVoltage, double inputCurrent, string testTag)
        {
            BasicComponentModel component = new BasicComponentModel("Component Name", "Component Description", "\\Images\\diode.png");
            (double voltageResult, double currentResult) output = component.GetOutput(inputVoltage, inputCurrent);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new BasicComponentModel!");
                Assert.That(output.voltageResult, Is.EqualTo(inputVoltage), $"Voltage output of a BasicComponentModel is incorrect using {testTag}");
                Assert.That(output.currentResult, Is.EqualTo(inputCurrent), $"Current output of a BasicComponentModel is incorrect using {testTag}");
            });
        }

        [TestCase(TestVoltage, TestCurrent, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, "mixed numbers")]
        [TestCase(0, 0, "zeros")]
        public void BasicComponentFormattedOutput(double inputVoltage, double inputCurrent, string testTag)
        {
            BasicComponentModel component = new BasicComponentModel("Component Name", "Component Description", "\\Images\\diode.png");
            string formattedOutput = component.DisplayValues(inputVoltage, inputCurrent);
            string expectedOutput = GetExpectedBaseComponentFormatedString(inputVoltage, inputCurrent, inputVoltage, inputCurrent);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new BasicComponentModel!");
                Assert.That(formattedOutput, Is.EqualTo(expectedOutput), $"Formatted output of a BasicComponentModel is incorrect using {testTag}");
            });
        }
        #endregion

        #region Capacitor Component
        [Test]
        public void CapacitorComponentCreate()
        {
            CapacitorComponentModel component = new CapacitorComponentModel("Component Name", "Component Description", "\\Images\\capacitor.png", StandardCapacitanceValue);
            Assert.IsNotNull(component, "Failed to create new CapacitorComponentModel!");
        }

        [TestCase(TestVoltage, TestCurrent, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, "mixed numbers")]
        [TestCase(0, 0, "zeros")]
        public void CapacitorComponentOutput(double inputVoltage, double inputCurrent, string testTag)
        {
            CapacitorComponentModel component = new CapacitorComponentModel("Component Name", "Component Description", "\\Images\\capacitor.png", StandardCapacitanceValue);
            (double voltageResult, double currentResult) output = component.GetOutput(inputVoltage, inputCurrent);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new CapcitorComponentModel!");
                Assert.That(output.voltageResult, Is.EqualTo(inputVoltage), $"Voltage output of a CapacitorComponentModel is incorrect using {testTag}");
                Assert.That(output.currentResult, Is.EqualTo(0), $"Current output of a CapacitorComponentModel is incorrect using {testTag}");
            });
        }

        [TestCase(TestVoltage, TestCurrent, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, "mixed numbers")]
        [TestCase(0, 0, "zeros")]
        public void CapacitorComponentFormattedOutput(double inputVoltage, double inputCurrent, string testTag)
        {
            CapacitorComponentModel component = new CapacitorComponentModel("Component Name", "Component Description", "\\Images\\capacitor.png", StandardCapacitanceValue);
            string formattedOutput = component.DisplayValues(inputVoltage, inputCurrent);
            string expectedOutput = GetExpectedBaseComponentFormatedString(inputVoltage, inputCurrent, inputVoltage, 0) + $"\n\nCapacitance: {StandardCapacitanceValue} farad(s)\tCharge: {inputVoltage * StandardCapacitanceValue}";
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new CapacitorComponentModel!");
                Assert.That(formattedOutput, Is.EqualTo(expectedOutput), $"Formatted output of a CapacitorComponentModel is incorrect using {testTag}");
            });
        }

        [TestCase(TestVoltage, TestCurrent, StandardCapacitanceValue, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, -StandardCapacitanceValue, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, StandardCapacitanceValue / 3, "mixed numbers")]
        [TestCase(0, 0, 0, "zeros")]
        public void CapacitorComponentFormattedOutputVarriedCapacitance(double inputVoltage, double inputCurrent, double capacitanceValue, string testTag)
        {
            CapacitorComponentModel component = new CapacitorComponentModel("Component Name", "Component Description", "\\Images\\capacitor.png", capacitanceValue);
            string formattedOutput = component.DisplayValues(inputVoltage, inputCurrent);
            string expectedOutput = GetExpectedBaseComponentFormatedString(inputVoltage, inputCurrent, inputVoltage, 0) + $"\n\nCapacitance: {capacitanceValue} farad(s)\tCharge: {inputVoltage * capacitanceValue}";
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new CapacitorComponentModel!");
                Assert.That(formattedOutput, Is.EqualTo(expectedOutput), $"Formatted output of a CapacitorComponentModel is incorrect using {testTag}");
            });
        }

        [TestCase(StandardCapacitanceValue)]
        [TestCase(-StandardCapacitanceValue)]
        [TestCase(StandardCapacitanceValue / 3)]
        [TestCase(0)]
        public void CapacitorComponentChangeCapacitance(double capacitanceValue)
        {
            CapacitorComponentModel component = new CapacitorComponentModel("Component Name", "Component Description", "\\Images\\capacitor.png", StandardCapacitanceValue);
            component.UpdateCapacitanceValue(capacitanceValue);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new CapacitorComponentModel!");
                Assert.That(component.CapacitanceValue, Is.EqualTo(capacitanceValue), "Failed to update the capacitance value of the component");
            });
        }
        #endregion

        #region Resistor Component
        [Test]
        public void ResistorComponentCreate()
        {
            ResistorComponentModel component = new ResistorComponentModel("Component Name", "Component Description", "\\Images\\resistor.png", StandardResistenceValue);
            Assert.IsNotNull(component, "Failed to create new ResistorComponentModel!");
        }

        [TestCase(TestVoltage, TestCurrent, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, "mixed numbers")]
        [TestCase(0, 0, "zeros")]
        public void ResistorComponentOutput(double inputVoltage, double inputCurrent, string testTag)
        {
            ResistorComponentModel component = new ResistorComponentModel("Component Name", "Component Description", "\\Images\\resistor.png", StandardResistenceValue);
            (double voltageResult, double currentResult) output = component.GetOutput(inputVoltage, inputCurrent);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new ResistorComponentModel!");
                Assert.That(output.voltageResult, Is.EqualTo(inputVoltage), $"Voltage output of a ResistorComponentModel is incorrect using {testTag}");
                Assert.That(output.currentResult, Is.EqualTo(inputVoltage/StandardResistenceValue), $"Current output of a ResistorComponentModel is incorrect using {testTag}");
            });
        }

        [TestCase(TestVoltage, TestCurrent, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, "mixed numbers")]
        [TestCase(0, 0, "zeros")]
        public void ResistorComponentFormattedOutput(double inputVoltage, double inputCurrent, string testTag)
        {
            ResistorComponentModel component = new ResistorComponentModel("Component Name", "Component Description", "\\Images\\resistor.png", StandardResistenceValue);
            string formattedOutput = component.DisplayValues(inputVoltage, inputCurrent);
            string expectedOutput = GetExpectedBaseComponentFormatedString(inputVoltage, inputCurrent, inputVoltage, inputVoltage/StandardResistenceValue) + $"\n\nResistance: {StandardResistenceValue} Ohm(s)";
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new CapacitorComponentModel!");
                Assert.That(formattedOutput, Is.EqualTo(expectedOutput), $"Formatted output of a CapacitorComponentModel is incorrect using {testTag}");
            });
        }

        [TestCase(TestVoltage, TestCurrent, 1000, "positive real numbers")]
        [TestCase(-TestVoltage, -TestCurrent, -15000, "negative real numbers")]
        [TestCase(TestMixedVoltage, TestMixedCurrent, -800.5, "mixed numbers")]
        [TestCase(0, 0, 0, "zeros")]
        public void ResistorComponentFormattedOutputVarriedResistence(double inputVoltage, double inputCurrent, double resistenceValue, string testTag)
        {
            ResistorComponentModel component = new ResistorComponentModel("Component Name", "Component Description", "\\Images\\resistor.png", resistenceValue);
            string formattedOutput = component.DisplayValues(inputVoltage, inputCurrent);
            string expectedOutput = GetExpectedBaseComponentFormatedString(inputVoltage, inputCurrent, inputVoltage, inputVoltage / resistenceValue) + $"\n\nResistance: {resistenceValue} Ohm(s)";
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new CapacitorComponentModel!");
                Assert.That(formattedOutput, Is.EqualTo(expectedOutput), $"Formatted output of a CapacitorComponentModel is incorrect using {testTag}");
            });
        }

        [TestCase(StandardResistenceValue)]
        [TestCase(-StandardResistenceValue)]
        [TestCase(StandardResistenceValue/3)]
        [TestCase(0)]
        public void ResistorComponentChangeResistence(double resistenceValue)
        {
            ResistorComponentModel component = new ResistorComponentModel("Component Name", "Component Description", "\\Images\\resistor.png", StandardResistenceValue);
            component.UpdateResistenceValue(resistenceValue);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(component, "Failed to create new ResistorComponentModel!");
                Assert.That(component.ResistanceValue, Is.EqualTo(resistenceValue), "Failed to change the resistence value of the component");
            });
        }
        #endregion

        #region Transistor Component
        public void TransistorComponentCreate()
        {

        }

        public void TransistorComponentOutput(double inputVoltage, double inputCurrent, string testTag)
        {

        }

        public void TransistorComponentFormattedOutput(double inputVoltage, double inputCurrent, string testTag)
        {

        }

        public void TransistorComponentFormattedOutputVarriedState(double inputVoltage, double inputCurrent, bool state, string testTag)
        {

        }

        // Can update state?
        #endregion

        #endregion

        #region Breadboard Model Tests

        #endregion

        #region Unit Model Tests

        #endregion

        #region Lesson Model Tests

        #endregion

        #region User Model Tests

        #endregion

        #endregion

        #region View Model Testing

        #endregion

        private string GetExpectedBaseComponentFormatedString(double inputVoltage, double inputCurrent, double outputVoltage, double outputCurrent)
        {
            return $"Inputs -\nVoltage: {inputVoltage} V\tCurrent: {inputCurrent} Amp(s)\n\nOutputs -\nVoltage: {outputVoltage} V\tCurrent: {outputCurrent} Amp(s)";
        }
    }
}