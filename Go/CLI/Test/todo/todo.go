package todo

import (
	"encoding/json"
	"fmt"
	"os"
)

type Item struct {
	ItemText string
}

func SaveItems(filename string, items []Item) error {
	j, err := json.Marshal(items)
	if err != nil {
		return err
	}
	fmt.Println(string(j))

	err = os.WriteFile(filename, j, 0644)
	if err != nil {
		return err
	}

	return nil
}

func ReadItems(filename string) ([]Item, error) {
	j, err := os.ReadFile(filename)
	if err != nil {
		return []Item{}, err
	}

	var items []Item

	if err := json.Unmarshal(j, &items); err != nil {
		return []Item{}, err
	}

	return items, nil
}
