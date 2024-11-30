package Helper

import (
	"fmt"
	"io"
	"net/http"
)

func GET(url string) ([]byte, error) {
	req, err := http.NewRequest("GET", url, nil)
	if err != nil {
		return nil, err
	}

	req.Header.Add("Content-Type", "text/plain")
	req.Header.Add("Cookie", "session=53616c7465645f5f740079d7620ae3461e0dd7db9e5722f92168f91f060ac0a0d091c3a0649a676da89c22e65049614f7b681416c069c5b8aea7dc5dc6abb9f6")

	fmt.Println("[GET] Making request to " + url)

	client := &http.Client{}

	resp, err := client.Do(req)
	if err != nil {
		return nil, err
	}
	defer resp.Body.Close()

	responseBody, err := io.ReadAll(resp.Body)
	if err != nil {
		return nil, err
	}

	return responseBody, nil

}
