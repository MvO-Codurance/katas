
#include "Method/include/AuthenticationService.h"

#include <gtest/gtest.h>

TEST( administratorIsAlwaysAuthenticated, AuthenticationServiceTest )
{
    AuthenticationService service;
    int adminId = 12345;
    EXPECT_TRUE(service.isAuthenticated(adminId));
}

TEST( normalUserIsNotAuthenticatedInitially, AuthenticationServiceTest )
{
    AuthenticationService service;
    int normalUserId = 11111;
    EXPECT_FALSE(service.isAuthenticated(normalUserId));
}
