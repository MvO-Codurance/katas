import XCTest

class ShoppingCartTest: XCTestCase {

    override func setUp() {
        super.setUp()
    }

    override func tearDown() {
        super.tearDown()
    }

    func testCartMayJustHaveASingleItem() {
        let shoppingCart = ShoppingCart()
        shoppingCart.add(10);
        XCTAssertEqual(1, shoppingCart.numberOfProducts())
    }

    func testTheTotalPriceOfTheCartIsTotalOfItsContents() {
        let shoppingCart = ShoppingCart()
        shoppingCart.add(10);
        XCTAssertEqual(10, shoppingCart.calculateTotalPrice())
    }

    func testHasDiscountWhenContainsAtLeastOnePremiumItem() {
        let shoppingCart = ShoppingCart()
        shoppingCart.add(100);
        XCTAssertTrue(shoppingCart.hasDiscount())
    }

    func testDoesntHaveDiscountWhenAllItemsAreCheap() {
        let shoppingCart = ShoppingCart()
        shoppingCart.add(10);
        XCTAssertFalse(shoppingCart.hasDiscount())
    }

}
