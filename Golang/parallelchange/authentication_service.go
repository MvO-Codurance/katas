package parallelchange

type AuthenticationService struct{}

func NewAuthenticationService() *AuthenticationService {
	return &AuthenticationService{}
}

//
// The goal is to replace the following method with:
// func (s *AuthenticationService) IsAuthenticated(role ???, userID int) bool
//

func (s *AuthenticationService) IsAuthenticated(userID int) bool {
	return userID == 12345
}
