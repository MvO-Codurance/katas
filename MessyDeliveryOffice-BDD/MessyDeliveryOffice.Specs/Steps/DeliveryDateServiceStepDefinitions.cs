namespace MessyDeliveryOffice.Specs.Steps;

[Binding]
public class DeliveryDateServiceStepDefinitions
{
    [Given(@"the id of a customer order")]
    public void GivenTheIdOfACustomerOrder()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"we ask for the estimated dispatch date for the order")]
    public void WhenWeAskForTheEstimatedDispatchDateForTheOrder()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the result should be the estimated dispatch date for the order")]
    public void ThenTheResultShouldBeTheEstimatedDispatchDateForTheOrder()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"the order is received by the supplier")]
    public void WhenTheOrderIsReceivedByTheSupplier()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the supplier starts to process the order on the same day")]
    public void ThenTheSupplierStartsToProcessTheOrderOnTheSameDay()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"a product that the supplier supplies that has a lead time of (.*) days")]
    public void GivenAProductThatTheSupplierSuppliesThatHasALeadTimeOfDays(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the order received date plus (.*) days falls on a week day")]
    public void GivenTheOrderReceivedDatePlusDaysFallsOnAWeekDay(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the product is sent to the delivery office (.*) days later")]
    public void ThenTheProductIsSentToTheDeliveryOfficeDaysLater(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the order received date plus (.*) days falls on a weekend")]
    public void GivenTheOrderReceivedDatePlusDaysFallsOnAWeekend(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the product is sent to the delivery office on the next weekday plus the remaining (.*) days")]
    public void ThenTheProductIsSentToTheDeliveryOfficeOnTheNextWeekdayPlusTheRemainingDays(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the day of the week is a weekday")]
    public void GivenTheDayOfTheWeekIsAWeekday()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"all products on the order have been received by the Delivery Office")]
    public void WhenAllProductsOnTheOrderHaveBeenReceivedByTheDeliveryOffice()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the order is dispatched to the customer on the same day")]
    public void ThenTheOrderIsDispatchedToTheCustomerOnTheSameDay()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"the day of the week is a weekend")]
    public void GivenTheDayOfTheWeekIsAWeekend()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the order is dispatched to the customer on the next weekday")]
    public void ThenTheOrderIsDispatchedToTheCustomerOnTheNextWeekday()
    {
        ScenarioContext.StepIsPending();
    }
}