
#include "../include/ClientOfAuthenticator.h"
#include "../include/AuthenticationService.h"

int main(int argc, char** argv) 
{
    ClientOfAuthenticator(AuthenticationService()).run();
    return 0;
}
