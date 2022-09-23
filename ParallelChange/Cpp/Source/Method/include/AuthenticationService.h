#pragma once

class AuthenticationService 
{
public:
    bool isAuthenticated(int id) 
    {
        return id == 12345;
    }
};
