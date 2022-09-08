
#include "Field/include/ShoppingCart.h"

#include <gtest/gtest.h>

TEST( singleItem_numberOfProductsInTheCart, ShoppingCartTest )
{
    ShoppingCart shoppingCart;
    shoppingCart.add(10);

    EXPECT_EQ(1, shoppingCart.numberOfProducts());
}

TEST( singleItem_totalPrice, ShoppingCartTest )
{
    ShoppingCart shoppingCart;
    shoppingCart.add(10);

    EXPECT_EQ(10, shoppingCart.calculateTotalPrice());
}

TEST( singleItem_hasDiscountIfContainsAtLeastOneProductWorthAtLeast100, ShoppingCartTest )
{
    ShoppingCart shoppingCart;
    shoppingCart.add(100);

    EXPECT_TRUE(shoppingCart.hasDiscount());
}

TEST( singleItem_doesNotHaveDiscountIfContainsNoProductsWorthAtLeast100, ShoppingCartTest )
{
    ShoppingCart shoppingCart;
    shoppingCart.add(99);

    EXPECT_FALSE(shoppingCart.hasDiscount());
}
