run:
	@ghc Main.hs -outputdir bin -o bin/app
	@make clean
	@echo "\033[0;31m[DONE]\033[0m"
	@bin/app

clean: 
	@rm bin/*.hi
	@rm bin/*.o