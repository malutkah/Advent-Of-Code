package day1

import (
	aoc "AoC/Helper"
)

func Solve() {
	var counter = 0
	var input = aoc.GetInput("2021", "day1", "testinput")

	for i := 0; i < len(input)-3; i++ {
		sum1 := aoc.StoI(input[i]) + aoc.StoI(input[i+1]) + aoc.StoI(input[i+2])
		nextSum := aoc.StoI(input[i+1]) + aoc.StoI(input[i+2]) + aoc.StoI(input[i+3])
		if nextSum > sum1 {
			counter++
		}
	}
	println(aoc.ItoS(counter))

}
