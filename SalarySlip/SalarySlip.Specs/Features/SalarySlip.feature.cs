﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SalarySlip.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class SalarySlipFeature : object, Xunit.IClassFixture<SalarySlipFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "SalarySlip.feature"
#line hidden
        
        public SalarySlipFeature(SalarySlipFeature.FixtureData fixtureData, SalarySlip_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Salary Slip", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Generate a salary slip for an employee with different taxation elements")]
        [Xunit.TraitAttribute("FeatureTitle", "Salary Slip")]
        [Xunit.TraitAttribute("Description", "Generate a salary slip for an employee with different taxation elements")]
        [Xunit.InlineDataAttribute("5000", "416.67", "0.00", "416.67", "0.00", "0.00", new string[0])]
        [Xunit.InlineDataAttribute("6000", "500.00", "0.00", "500.00", "0.00", "0.00", new string[0])]
        [Xunit.InlineDataAttribute("9060", "755.00", "10.00", "755.00", "0.00", "0.00", new string[0])]
        [Xunit.InlineDataAttribute("11000", "916.67", "29.40", "916.67", "0.00", "0.00", new string[0])]
        [Xunit.InlineDataAttribute("12000", "1000.00", "39.40", "916.67", "83.33", "16.67", new string[0])]
        [Xunit.InlineDataAttribute("30000", "2500.00", "219.40", "916.67", "1583.33", "316.67", new string[0])]
        [Xunit.InlineDataAttribute("45000", "3750.00", "352.73", "916.67", "2833.33", "600.00", new string[0])]
        public virtual void GenerateASalarySlipForAnEmployeeWithDifferentTaxationElements(string gross_Salary, string monthly_Gross_Salary, string national_Insurance, string tax_Free_Allowance, string taxable_Income, string tax_Payable, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("gross_salary", gross_Salary);
            argumentsOfScenario.Add("monthly_gross_salary", monthly_Gross_Salary);
            argumentsOfScenario.Add("national_insurance", national_Insurance);
            argumentsOfScenario.Add("tax_free_allowance", tax_Free_Allowance);
            argumentsOfScenario.Add("taxable_income", taxable_Income);
            argumentsOfScenario.Add("tax_payable", tax_Payable);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate a salary slip for an employee with different taxation elements", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
 testRunner.Given(string.Format("an employee with a gross annual salary of {0}", gross_Salary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
 testRunner.When("we generate a salary slip for the employee", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 6
 testRunner.Then(string.Format("the salary slip should contain a gross monthly salary of {0}", monthly_Gross_Salary), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 7
 testRunner.And(string.Format("national insurance contribution of {0}", national_Insurance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
 testRunner.And(string.Format("tax-free allowance of £ {0}", tax_Free_Allowance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
 testRunner.And(string.Format("taxable income of £ {0}", taxable_Income), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.And(string.Format("tax payable of £ {0}", tax_Payable), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                SalarySlipFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SalarySlipFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
