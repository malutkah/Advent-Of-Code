package day2

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
)

func Solve() {
	var input = aoc.GetInput("2021", "day2", "testinput")
	var horizontal int
	var depth int
	var aim int

	for i := 0; i < len(input); i++ {
		path := strings.Split(input[i], " ")
		dir := path[0]
		amount := aoc.StoI(path[1])

		switch dir {
		case "forward":
			horizontal += amount
			depth += aim * amount
		case "down":
			aim += amount
		case "up":
			aim -= amount
		}

	}

	fmt.Printf("Horizontal amount: %v\n", horizontal)
	fmt.Printf("Depth amount: %v\n", depth)
	fmt.Printf("Total amount: %v\n", depth*horizontal)
}
