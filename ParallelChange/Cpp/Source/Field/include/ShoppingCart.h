#pragma once

class ShoppingCart 
{
    int m_price;

public:
    void add(int price) 
    {
        m_price = price;
    }

    int calculateTotalPrice() 
    {
        return m_price;
    }

    bool hasDiscount() 
    {
        return m_price >= 100;
    }

    int numberOfProducts() 
    {
        return 1;
    }
};
