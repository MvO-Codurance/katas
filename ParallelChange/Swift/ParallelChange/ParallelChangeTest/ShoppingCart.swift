import XCTest

class ShoppingCart {
    var price = 0

    // the goal is to remove a field above, replacing with
    // `prices = []`

    func add(price: Int) {
        self.price = price
    }

    func numberOfProducts() -> Int {
        return 1
    }

    func calculateTotalPrice() -> Int {
        return self.price
    }

    func hasDiscount() -> Bool {
        return self.price >= 100
    }
}


class SomeConsumer {
    func doStuff() {
        let shoppingCart = ShoppingCart()
        shoppingCart.add(100)
        print("other consumer: \(shoppingCart.calculateTotalPrice())")
    }
}

class ShoppingCartMain: XCTestCase {
    func runExample() {
        let shoppingCart = ShoppingCart()
        shoppingCart.add(10)
        print("number of products: \(shoppingCart.numberOfProducts())")
        print("total price: \(shoppingCart.calculateTotalPrice())")
        print("has discount: \(shoppingCart.hasDiscount())")
    }

    func testRunExample() {
        runExample()
    }
}