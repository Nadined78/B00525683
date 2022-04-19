{ pkgs }: {
    deps = [
        pkgs.dotnet-sdk
        pkgs.omnisharp-roslyn
        pkgs.zip
        pkgs.unzip
        pkgs.sqlite
    ];
}