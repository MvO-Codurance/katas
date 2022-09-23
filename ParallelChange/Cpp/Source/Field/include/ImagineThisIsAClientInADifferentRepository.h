#pragma once

#include "ShoppingCart.h"

#include <string>
#include <sstream>

struct ImagineThisIsAClientInADifferentRepository
{
    std::string formattedTotalPrice( int price ) 
    {
        ShoppingCart shoppingCart;
        shoppingCart.add(price);
        std::ostringstream os;
        os << "Total price is " << shoppingCart.calculateTotalPrice() << " euro";
        return os.str();
    }
};
