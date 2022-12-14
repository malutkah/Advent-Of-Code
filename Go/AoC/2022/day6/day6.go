package day6

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day6", "test")

	datastream := inputs[0]

	t := ""

	// qmgbljsphdztnv
	// mjqjp qmgbljsphdztnv jfqwrcgsmlb

	for _, marker := range datastream {

		if !strings.Contains(t, aoc.RtoS(marker)) {
			t += aoc.RtoS(marker)

			if len(t) == 14 {
				fmt.Println(t)
				fmt.Println(strings.IndexRune(datastream, marker))
				break
			}
		} else {
			t = ""
		}
	}

}
