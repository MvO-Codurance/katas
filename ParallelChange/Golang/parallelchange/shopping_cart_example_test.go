package parallelchange

import "fmt"

func ExampleSomeConsumer() {
	shoppingCart := NewShoppingCart()
	shoppingCart.Add(100)
	fmt.Printf("other consumer: %d\n", shoppingCart.CalculateTotalPrice())
	// Output: other consumer: 100
}

func ExampleMainConsumer() {
	shoppingCart := NewShoppingCart()
	shoppingCart.Add(10)

	fmt.Printf("number of products: %d\n", shoppingCart.NumberOfProducts())
	fmt.Printf("total price: %d\n", shoppingCart.CalculateTotalPrice())
	fmt.Printf("has discount: %v\n", shoppingCart.HasDiscount())
	// Output:
	// number of products: 1
	// total price: 10
	// has discount: false
}
