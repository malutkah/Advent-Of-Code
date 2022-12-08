package day5

import (
	aoc "AoC/Helper"
	"fmt"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day5", "test")
	var crates []string
	// get the crates: [N], [W], ...
	// get move commands

	for _, i := range inputs {
		if i == "" {
			break
		}
		crates = append(crates, i)
	}

	getCrate(crates)
}

func getCrate(crates []string) {
	/*
		a crate is defined by 3 chars => [N]
		row width = 3
		rows are seperated by spaces => " "

	*/

	// rowWidth := 3
	// row := 8

	fmt.Println(len(crates[cap(crates)-1]))

	// print third row
	// third row = crates[cap(crates)-1] to crates[cap(crates)-3]

}
