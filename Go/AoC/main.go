/*
Copyright © 2024 malutkah <alan.tressin@outlook.com>
*/
package main

import (
	"os"

	"AoC/2021/day3"
	"AoC/cmd"
)

func main() {
	os.Setenv("SOLVE_DAY1", "false")
	cmd.Execute()

	if shouldSolve() {
		day3.Solve()
	}
}

func shouldSolve() bool {
	return os.Getenv("SOLVE_DAY1") == "true"
}
