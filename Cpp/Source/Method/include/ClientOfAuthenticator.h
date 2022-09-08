#pragma once

#include "AuthenticationService.h"

#include <iostream>

class ClientOfAuthenticator 
{
    AuthenticationService m_authenticationService;   

public:
    ClientOfAuthenticator(AuthenticationService authenticationService) 
    {
        m_authenticationService = authenticationService;
    }

    void run() 
    {
        bool authenticated = m_authenticationService.isAuthenticated(33);
        std::cout << "33 is authenticated = " << authenticated << '\n';
    }
};
