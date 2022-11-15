package main

import (
	"fmt"
	"os"
)

func main() {
	var day string
	var year string
	var templateText string

	// get year -> input: number
	fmt.Println("Enter the year (yyyy): ")
	_, yerr := fmt.Scan(&year)
	if yerr != nil {
		return
	}

	// get day -> input: number
	fmt.Println("Enter the day: ")
	_, derr := fmt.Scan(&day)
	if derr != nil {
		return
	}
	day = "day" + day
	y := "\"" + year + "\""
	d := "\"" + day + "\""
	a := "\"AoC/Helper\""
	i := "import aoc " + a
	templateText = "package " + day + "\n\n" + i + "\n\nfunc Test() {\nvar inputs = aoc.GetInput(" + y + ", " + d + ", \"test\"" + ")\n}"

	// get template
	createTemplate(year, day, templateText)

}

func createDayFolder(year string, day string) {
	if _, err := os.Stat("/" + year); os.IsNotExist(err) {
		// dir of that year does not exist
		if err := os.MkdirAll(year+"/"+day, os.ModePerm); err != nil {
			return
		}
	} else {
		if err := os.MkdirAll("/"+year+"/"+day, os.ModePerm); err != nil {
			return
		}
	}

}

func createTemplate(year string, day string, templateText string) {
	createDayFolder(year, day)

	var path = year + "/" + day + "/"

	err := os.WriteFile(path+day+".go", []byte(templateText), 0755)
	if err != nil {
		fmt.Printf("Unable to write file: %v", err)
	}

	err = os.WriteFile(path+"input.txt", []byte(""), 0755)
	if err != nil {
		fmt.Printf("Unable to write file: %v", err)
	}

	err = os.WriteFile(path+"test.txt", []byte(""), 0755)
	if err != nil {
		fmt.Printf("Unable to write file: %v", err)
	}
}
