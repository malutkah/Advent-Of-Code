package day4

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day4", "input")
	c := 0
	o := 0

	for _, l := range inputs {
		sections := strings.Split(l, ",")

		s1 := sections[0]
		s2 := sections[1]

		// section 1
		pair1 := strings.Split(s1, "-")
		id1 := aoc.StoI(pair1[0])
		id2 := aoc.StoI(pair1[1])

		// get range
		range1 := []int{id1, id2}

		for i := 0; i <= 9; i++ {
			if i >= id1 && i <= id2 {
				fmt.Printf("%d", i)
			} else {
				fmt.Print(".")
			}
		}
		fmt.Printf(": %v\n", pair1)

		// section 2
		pair2 := strings.Split(s2, "-")
		id1 = aoc.StoI(pair2[0])
		id2 = aoc.StoI(pair2[1])

		range2 := []int{id1, id2}

		for i := 0; i <= 9; i++ {
			if i >= id1 && i <= id2 {
				fmt.Printf("%d", i)
			} else {
				fmt.Print(".")
			}
		}
		fmt.Printf(": %v\n\n", pair2)

		containing := (range1[0] >= range2[0] && range1[1] <= range2[1]) || (range2[0] >= range1[0] && range2[1] <= range1[1])
		if containing {
			c++
		}

		overlapping := (range1[0] <= range2[0] && range1[1] >= range2[0]) || (range2[0] <= range1[0] && range2[1] >= range1[0])

		if overlapping {
			o++
		}

		range1 = nil
		range2 = nil
	}

	fmt.Printf("%d pairs fully contain the other\n\n", c)
	fmt.Printf("%d overlapping pairs: \n\n", o)
}
