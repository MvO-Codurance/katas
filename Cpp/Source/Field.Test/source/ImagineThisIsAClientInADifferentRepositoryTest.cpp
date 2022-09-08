
#include "Field/include/ImagineThisIsAClientInADifferentRepository.h"

#include <gtest/gtest.h>

TEST( singleItem_numberOfProductsInTheCart, ImagineThisIsAClientInADifferentRepositoryTest )
{
    ImagineThisIsAClientInADifferentRepository client;

    EXPECT_EQ(std::string("Total price is 50 euro"), client.formattedTotalPrice(50));
}
