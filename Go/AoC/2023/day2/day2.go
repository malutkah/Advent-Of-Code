package day2

import (
	"fmt"
	"strings"

	aoc "AoC/Helper"
)

func Solve() {
	var inputs = aoc.GetInput("2023", "day2", "test")

	possibleCount := 0
	// cubeMap := make(map[string]int)

	for _, game := range inputs {
		id := aoc.StoI(strings.Split(game, ":")[0][5:])
		s := strings.Split(game, ":")[1]
		cubeSets := strings.Split(s, ";")
		_ = id

		for _, v := range cubeSets {
			sets := strings.Split(v, ",")
			fmt.Println(sets)
		}
		fmt.Println()
	}

	fmt.Println(possibleCount)
}
