package day1

import (
	aoc "AoC/Helper"
	"fmt"
	"sort"
	"strconv"
	"strings"
)

func Solve() {
	var inputs = aoc.GetInput("2024", "day1", "input")
	var leftSide []int
	var rightSide []int

	for _, line := range inputs {
		cols := strings.Split(line, "   ")
		leftNum, _ := strconv.Atoi(cols[0])
		rightNum, _ := strconv.Atoi(cols[1])
		leftSide = append(leftSide, leftNum)
		rightSide = append(rightSide, rightNum)
	}

	sort.Ints(leftSide)
	sort.Ints(rightSide)

	var sum int
	for id := 0; id < len(leftSide); id++ {
		d := leftSide[id] - rightSide[id]
		if d < 0 {
			d = -d
		}
		sum += d
	}

	fmt.Println("sum:", sum)
}

func Solved() {
	var inputs = aoc.GetInput("2024", "day1", "input")
	var leftSide []int
	var rightSide []int

	for _, line := range inputs {
		cols := strings.Split(line, "   ")
		leftNum, _ := strconv.Atoi(cols[0])
		rightNum, _ := strconv.Atoi(cols[1])
		leftSide = append(leftSide, leftNum)
		rightSide = append(rightSide, rightNum)
	}

	rightSideMap := make(map[int]int)
	for _, n := range rightSide {
		rightSideMap[n]++
	}

	var counts []int
	for _, num := range leftSide {
		count := rightSideMap[num]
		counts = append(counts, num*count)
	}

	var sum int
	for _, c := range counts {
		sum += c
	}

	fmt.Println("sum:", sum)
}
