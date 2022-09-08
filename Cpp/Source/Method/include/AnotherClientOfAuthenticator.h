#pragma once

#include "AuthenticationService.h"

class AnotherClientOfAuthenticator 
{
public:
    void unusedClientCode() 
    {
        try 
        {
            AuthenticationService().isAuthenticated(3545);
        } 
        catch (Exception e) 
        {
            // ignored
        }
    }
};
