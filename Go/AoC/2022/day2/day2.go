package day2

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day2", "test")
	totalScore := 0

	for _, draws := range inputs {
		var rounds = strings.Split(draws, " ")
		enemy := 0
		score := 0
		state := ""

		if rounds[0] == "A" {
			enemy = 1
		} else if rounds[0] == "B" {
			enemy = 2
		} else {
			enemy = 3
		}

		if rounds[1] == "X" {
			state = "lose"
		} else if rounds[1] == "Y" {
			state = "draw"
		} else {
			state = "win"
		}

		switch state {
		case "lose":
			if enemy == 1 {
				score = 3
			} else if enemy == 2 {
				score = 1
			} else {
				score = 2
			}
		case "draw":
			score = enemy
		case "win":
			if enemy == 1 {
				score = 2
			} else if enemy == 3 {
				score = 1
			} else {
				score = 3
			}
		}

		switch score {
		case 1:
			if enemy == 1 {
				score += 3
			} else if enemy == 2 {
				score += 0
			} else {
				score += 6
			}

		case 2:
			if enemy == 1 {
				score += 6
			} else if enemy == 2 {
				score += 3
			} else {
				score += 0
			}

		case 3:
			if enemy == 1 {
				score += 0
			} else if enemy == 2 {
				score += 6
			} else {
				score += 0
			}
		}
		fmt.Printf("my score %d\n", score)
		totalScore += score
	}
	fmt.Printf("my total score %d\n", totalScore)

}
