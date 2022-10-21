namespace MessyDeliveryOffice.Specs.Steps;

[Binding]
public class DeliveryDateServiceStepDefinitions
{
    [Given(@"the ID of a customer order")]
    public void GivenTheIdOfACustomerOrder()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I ask for an estimated delivery date")]
    public void WhenIAskForAnEstimatedDeliveryDate()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the result should be the estimated delivery date")]
    public void ThenTheResultShouldBeTheEstimatedDeliveryDate()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"a supplier that supplies a product")]
    public void GivenASupplierThatSuppliesAProduct()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the product has a (.*) lead time")]
    public void GivenTheProductHasALeadTime(string numberOfDays)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"the product is ordered")]
    public void WhenTheProductIsOrdered()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the product is delivered (.*) later")]
    public void ThenTheProductIsDeliveredLater(string numberOfDays)
    {
        ScenarioContext.StepIsPending();
    }
}