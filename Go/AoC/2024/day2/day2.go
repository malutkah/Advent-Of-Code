package day2

import (
	aoc "AoC/Helper"
	"fmt"
	"strconv"
	"strings"
)

func remove(slice []int, s int) []int {
	return append(slice[:s], slice[s+1:]...)
}

func isMonotonic(slice []int) bool {
	if len(slice) < 2 {
		return true
	}

	increasing := true
	decreasing := true

	for i := 0; i < len(slice)-1; i++ {
		diff := slice[i+1] - slice[i]
		if diff < 1 || diff > 3 {
			increasing = false
		}
		if diff > -1 || diff < -3 {
			decreasing = false
		}
	}

	return (increasing && !decreasing) || (!increasing && decreasing)
}

func canBeMadeMonotonic(slice []int) bool {
	for i := range slice {
		newSlice := remove(slice, i)
		if isMonotonic(newSlice) {
			return true
		}
	}
	return false
}

func Solve() {
	var inputs = aoc.GetInput("2024", "day2", "test")

	safeCount := 0
	for _, line := range inputs {
		r := strings.Split(line, " ")
		reports := make([]int, len(r))

		for i, s := range r {
			num, err := strconv.Atoi(s)
			if err != nil {
				fmt.Println("Error converting string to int:", err)
				return
			}
			reports[i] = num
		}

		if isMonotonic(reports) || canBeMadeMonotonic(reports) {
			fmt.Printf("%v is safe\n", reports)
			safeCount++
		}
	}
	fmt.Printf("%v reports are safe", safeCount)

}
