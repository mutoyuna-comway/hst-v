@echo off
setlocal enabledelayedexpansion

echo C#ファイルのCloneメソッド検索を開始します...
echo ---------------------------------------------------

rem カレントディレクトリの.csファイルを検索
for %%f in (*.cs) do (
    rem "Clone"の後に"("が続くパターン、または "Clone (" のようなパターンを検索
    rem /I: 大文字小文字を区別しない
    findstr /I /R "Clone\s*(" "%%f" >nul
    
    if !errorlevel! equ 0 (
        echo [yes] %%f
    ) else (
        echo [no] %%f
    )
)

echo ---------------------------------------------------
echo チェック完了
pause