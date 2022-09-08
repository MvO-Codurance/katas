
#include "../include/ShoppingCart.h"

#include <iostream>

int main(int argc, char** argv) 
{
    ShoppingCart shoppingCart;
    shoppingCart.add(10);
    std::cout 
        << "shoppingCart.numberOfProducts() = " << shoppingCart.numberOfProducts() << '\n'
        << "shoppingCart.calculateTotalPrice() = " << shoppingCart.calculateTotalPrice() << '\n'
        << "shoppingCart.hasDiscount() = " << shoppingCart.hasDiscount();
        
    return 0;
}
