package parallelchange

import "testing"

func TestAdministratorIsAlwaysAuthenticated(t *testing.T) {
	service := NewAuthenticationService()
	adminID := 12345

	expected := true
	if actual := service.IsAuthenticated(adminID); actual != expected {
		t.Errorf("Expected authenticated to be %v, but got %v", expected, actual)
	}
}

func TestNormalUserIsNotInitiallyAuthenticated(t *testing.T) {
	service := NewAuthenticationService()
	userID := 11111

	expected := false
	if actual := service.IsAuthenticated(userID); actual != expected {
		t.Errorf("Expected authenticated to be %v, but got %v", expected, actual)
	}
}
