SHELL = /bin/sh
prefix = /usr/local
CC = $(prefix)/bin/gmcs
MONO = $(prefix)/bin/mono
XUNIT = $(prefix)/mono/xunit
LDFLAGS = -lib:packages
LDLIBS = xunit.dll,xunit.extensions.dll,FluentAssertions.dll,FluentAssertions.Core.dll,Ploeh.AutoFixture.dll,Ploeh.AutoFixture.Xunit.dll
CFLAGS = -target:library -reference:$(LDLIBS)

all:
	$(CC) $(LDFLAGS) $(CFLAGS) -out:bin/GameOfLife.dll Source/*.cs
	$(MONO) "$(XUNIT)/xunit.console.clr4.exe" bin/GameOfLife.dll
