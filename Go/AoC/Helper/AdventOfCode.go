package Helper

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"os/exec"
	"runtime"
	"strconv"
	"strings"
)

/*
	- create day
	-y => year
	-d => day
		aoc new -y -d [year] [day]
		=>	aoc new -y -d 2021 1
		=>	aoc new -y 2021
		=>	aoc new -d 2 at -y 2021

	- start day
		aoc start [day] [year]
			aoc start 4 2021
*/
/* ========== CREATE NEW DAY ============================================================================================== */

func NewDay(day, year string) {
	d, _ := strconv.Atoi(day)
	y, _ := strconv.Atoi(year)

	if isYearValid(y) && isDayValid(d) {
		day = "day" + day

		templateText := setTemplateValues(year, day, "AoCTemplate")
		createTemplate(year, day, templateText)

		fmt.Printf("Created %v in year %v", day, year)
	} else {
		fmt.Println("No valid day or year was entered!")
		fmt.Println("Day has to be between 1 and 25!")
		fmt.Println("The year has to be between 2015 and 2022!")
	}
}

func isDayValid(day int) bool {
	return day > 0 && day < 26
}

func isYearValid(year int) bool {
	return year > 2014 && year < 2023
}

func setTemplateValues(year, day, fileName string) string {
	f, err := os.Open("Helper/" + fileName + ".txt")
	if err != nil {
		log.Fatal(err)
	}

	defer func(f *os.File) {
		err := f.Close()
		if err != nil {
			panic(err)
		}
	}(f)

	scanner := bufio.NewScanner(f)

	var inputs []string

	for scanner.Scan() {
		inputs = append(inputs, scanner.Text())
	}

	for i := 0; i < len(inputs); i++ {
		if strings.Contains(inputs[i], "day") {
			inputs[i] = strings.Replace(inputs[i], "day", day, -1)
		}
		if strings.Contains(inputs[i], "year") {
			inputs[i] = strings.Replace(inputs[i], "year", year, -1)
		}
	}

	return strings.Join(inputs, "\n")
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

/* ======================================================================================================== */

/* ========== START A DAY ================================================================================================= */

func StartDay(day, year string) {
	canStart := false

	// check if year is available (is year a dir?)
	if y := isYearDirectory(year); y {
		// check if day is available (is day a dir in year?)
		canStart = isDayInsideYear(day, year)
	} else {
		fmt.Println("year is NOT available")
	}

	if canStart {
		day = "day" + day
		t := setTemplateValues(year, day, "main_template")

		// create new main.go file to execute
		err := os.WriteFile("main.go", []byte(t), 0755)
		if err != nil {
			fmt.Printf("Unable to write file: %v", err)
			return
		}

		cmd := exec.Command("go", "build")
		//cmd := exec.Command("echo", "starting day...")
		out, err := cmd.Output()

		if err != nil {
			fmt.Println("couldn't start date")
			log.Fatal(err)
		}

		fmt.Println(string(out))
	}
}

func isYearDirectory(year string) bool {
	var cmd *exec.Cmd

	if runtime.GOOS == "windows" {
		fmt.Println("is windows")
		cmd = exec.Command("cmd", "/C", "dir")
	} else {
		fmt.Println("is not windows")
		cmd = exec.Command("cmd", "/C", "ls", "./")
	}

	out, err := cmd.Output()

	if err != nil {
		fmt.Println("error at isYearDirectory")
		log.Fatal(err)
	}

	if strings.Contains(string(out), year) {
		return true
	}
	return false
}

func isDayInsideYear(day, year string) bool {
	var cmd *exec.Cmd

	if runtime.GOOS == "windows" {
		fmt.Println("is windows")
		cmd = exec.Command("cmd", "/C", "dir", year)
	} else {
		fmt.Println("is not windows")
		cmd = exec.Command("ls", "./"+year)
	}

	out, err := cmd.Output()

	if err != nil {
		fmt.Println("error at isDayInsideYear")
		log.Fatal(err)
	}

	if strings.Contains(string(out), day) {
		return true
	}
	return false
}

/* ======================================================================================================== */
