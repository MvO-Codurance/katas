package parallelchange

type ShoppingCart struct {

	//
	// the goal is to remove this field, replacing with:
	// prices []int
	//

	price int
}

func NewShoppingCart() *ShoppingCart {
	return &ShoppingCart{}
}

func (c *ShoppingCart) Add(price int) {
	c.price = price
}

func (c *ShoppingCart) NumberOfProducts() int {
	return 1
}

func (c *ShoppingCart) CalculateTotalPrice() int {
	return c.price
}

func (c *ShoppingCart) HasDiscount() bool {
	return c.price >= 100
}
