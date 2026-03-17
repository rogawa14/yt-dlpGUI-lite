---------------------------------------------------
yt-dlp GUI Lite - README / 使い方
---------------------------------------------------

Version: 2.0
Author: rogawa
Website: https://github.com/rogawa14/yt-dlp_gui

本ソフトは yt-dlp をより簡単に使えるようにした GUI (グラフィカルユーザーインターフェイス) です。
yt-dlp と ffmpeg を同梱しており、動画や音声のダウンロードを簡単に行えます。

---------------------------------------------------
[Requirements / 動作環境]
- Windows 10 / 11
- yt-dlp.exe (同梱)
- ffmpeg.exe (同梱, GPL)
- .NET Runtime 6.0 以上（Windows 向けランタイム）
- インターネット接続（動画取得・ダウンロード用）

※ yt-dlp と ffmpeg は同梱済みのため、別途インストール不要です。
※ .NET Runtime がない場合、Microsoft の公式サイトからインストールしてください。
  https://dotnet.microsoft.com/download/dotnet/6.0
もしくはエラーが出た際の通知に従うことでダウンロードできます。

---------------------------------------------------
[Features / 機能]
- プレイリストの URL を貼ることで、プレイリスト内の全動画を一括ダウンロード
- 動画の詳細情報（タイトル、チャンネル、再生回数、サイズ、時間）とサムネイルを表示
- 以前のバージョンよりも安定かつ軽量
- GUI から yt-dlp 本体を簡単にアップデート可能
- 画質選択：1080p または 720p
- ダークモード対応
- 保存先を自由に選択可能
- ダウンロード進捗と速度をリアルタイムで確認可能
- MP3 変換対応（音声抽出）

---------------------------------------------------
[How to Use / 使い方]
1. URL ボックスに動画またはプレイリストの URL を貼り付けます。
2. 動画の情報が自動取得されます。
3. MP4 または MP3 を選択します。
4. 画質（1080p / 720p）を選択します。
5. 保存先を設定します。
6. [Download] ボタンをクリックしてダウンロード開始。
7. プログレスバーで進捗と速度を確認できます。
8. [Update yt-dlp] ボタンで yt-dlp を最新バージョンに更新可能。
9. [Dark Mode] で UI の表示を切替可能。

---------------------------------------------------
[Notes / 注意事項]
- このソフトは yt-dlp の GUI であり、yt-dlp 本体の機能に依存します。
- 著作権保護されたコンテンツのダウンロードは法律で禁止されている場合があります。
- 使用は自己責任でお願いします。
- 配布には yt-dlp (MIT License) と ffmpeg (GPL) のライセンス条件を遵守してください。
- yt-dlp 本体は BSD 2-Clause License のもとで配布可能
- ffmpeg は GPL ライセンスの条件に従う必要があります
- GUI ソフトは yt-dlp のフロントエンドとして機能するのみです


yt-dlp License (BSD 2-Clause)
-----------------------------
Copyright (c) 2023, yt-dlp authors
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice,
   this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
THE POSSIBILITY OF SUCH DAMAGE.

---

日本語訳
----------
yt-dlp BSD 2条項ライセンス

著作権 (c) 2023, yt-dlp 作者
全著作権保持

ソースコードおよびバイナリ形式での再配布と使用は、改変の有無にかかわらず
以下の条件を満たす限りにおいて許可されます:

1. ソースコードの再配布には、上記の著作権表示、この条件リスト、以下の免責条項を含めること。

2. バイナリ形式の再配布には、上記の著作権表示、この条件リスト、以下の免責条項を
   ドキュメントまたはその他配布物に記載すること。

本ソフトウェアは「現状のまま」提供され、明示的または黙示的な保証は一切ありません。
商品性や特定目的適合性の保証も含まれません。
著作権保持者および貢献者は、使用に起因するいかなる損害についても責任を負いません。

---------------------------------------------------
[Support / サポート]
- ソースコード・更新情報・不具合報告はこちら：
  https://github.com/rogawa14/yt-dlp_gui