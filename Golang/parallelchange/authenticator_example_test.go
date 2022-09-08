package parallelchange

import "fmt"

type AuthenticationClient struct {
	authenticationService *AuthenticationService
}

func (c *AuthenticationClient) Run() {
	authenticated := c.authenticationService.IsAuthenticated(33)
	fmt.Printf("authenticated: %v\n", authenticated)
}

func ExampleMainAuhenticationClient() {
	client := &AuthenticationClient{NewAuthenticationService()}
	client.Run()
	// Output: authenticated: false
}

func ExampleYetAotherClient() {
	NewAuthenticationService().IsAuthenticated(100)
	// Output:
}
