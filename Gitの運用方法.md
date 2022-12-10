# Issueとは
### 目的
　メンバー間でのタスクを可視化し管理する
　コメントを通して修正箇所についてやりとりする

### 作成手順
　**タイトル**：追加する機能やタスクを書く（簡潔にわかりやすく/日本語でOK）
　**内容**：
　**Assignees**：取り掛かる人
　**Labels**：
　**Projects**：post-team07_Projects
　**Status**：今のStatus

# ブランチについて
https://qiita.com/mint__/items/bfc58589b5b1e0a1856a

### git flow
開発ブランチはdevelop (defaultブランチにする)

### ブランチの命名規則
ブランチ名 | 役割 | 派生元 | マージ先
-- | -- | -- | --
master | 公開するものを置くブランチ |   |  
develop | 開発中のものを置くブランチ | master | master
release | 次にリリースするものを置くブランチ | develop | develop, master
feature-* | 新機能開発中に使うブランチ | develop | develop
hotfix-* | 公開中のもののバグ修正用ブランチ | master | develop, master
（日本語はだめ）

{上表のブランチ名}/#{issue番号}_{スネークケース}
例 feature/#12_replace_to_hamburger_menu

# コミット
### 粒度
　プルリクよりも小さい単位
　サブタスク単位とか本日の作業終了時とか、キリが良いタイミングがあればコミット

### コミットメッセージ
　https://suwaru.tokyo/【必須】gitコミットの書き方・作法【prefix-emoji】/

# PullRequest
### 目的
　変更を本人以外がレビューしてから反映させること

### 作成手順
　**タイトル**：変更の内容(日本語でOK)
　**内容**：何をレビューしてほしいのかやどうすればそれが確認できるか書いてあると◎
　**Reviewer**：レビューしてもらう人

# 開発の流れ

1. Issueを切る（選ぶ）
2. ブランチを切る
　Defaultブランチに行って新しいブランチを切る
3. ブランチ先で開発(適度な粒度でコミット)
4.  push originして進捗をGithubにあげる
5. Pull Requestを出す
6. レビューしてもらう
　Reviewerになったらpull requestの内容をチェックし動作確認を行う 
　対象ブランチに移動して動作確認
7. マージ
