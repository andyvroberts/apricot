import cmd

class ConsoleMain(cmd.Cmd):
    """The entry point for the apricot console"""
    prompt = "(apricot)"
    intro = "choose an option."

    def do_hello(self, line):
        print("Hello")

    def do_EOF(self, line):
        return True





if __name__ == "__main__":
    ConsoleMain().cmdloop()
