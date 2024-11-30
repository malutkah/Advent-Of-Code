/*
Copyright © 2022 NAME HERE <EMAIL ADDRESS>
*/
package cmd

import (
	"fmt"
	"os"

	"AoC/Helper"
	"github.com/spf13/cobra"
)

// newCmd represents the new command
var newCmd = &cobra.Command{
	Use:   "new",
	Short: "Creates a new folder for a Year and Day",
	Long: `The new command creates a new folder structure for the specified year and day for the Advent of Code challenge.

Usage:
  aoc new [year] [day]

Examples:
  aoc new 2023 1  # Creates a new folder for day 1 of the year 2023
  aoc new 2022 15 # Creates a new folder for day 15 of the year 2022

This command sets up the necessary files and environment to begin solving the challenge for the specified day and year.`,
	Run: newRun,
}

func newRun(cmd *cobra.Command, args []string) {
	if len(args) == 2 {
		os.Setenv("SOLVE_DAY1", "false")
		Helper.NewDay(args[0], args[1])
	} else {
		fmt.Println("Invalid arguments! Enter only 2")
	}
}

func init() {
	rootCmd.AddCommand(newCmd)

	// Here you will define your flags and configuration settings.

	// Cobra supports Persistent Flags which will work for this command
	// and all subcommands, e.g.:
	// newCmd.PersistentFlags().String("foo", "", "A help for foo")

	// Cobra supports local flags which will only run when this command
	// is called directly, e.g.:
	// newCmd.Flags().BoolP("toggle", "t", false, "Help message for toggle")
}
