using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();       
        for (int i = 1; i <= 3; i++)
        {
            Video video = new Video();
            video.SetTitle($"Video {i}");
            video.SetAuthor($"Author {i}");
            video.SetDuration(i * 60);
            video.SetComments(new List<Comment>());

            
            for (int j = 1; j <= 3; j++)
            {
                Comment comment = new Comment();
                comment.SetCommenterName($"commentator {j}");
                comment.SetText($"This is the comment {j} in the video {i}");

                video.GetComments().Add(comment);
            }

            videos.Add(video);
        }
      
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}, Author: {video.GetAuthor()}, Duration: {video.GetDuration()} seconds , Coment Amount : {video.GetCommentCount()}");
            Console.WriteLine("comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
public class Comment
{
    private string _commentName;
    private string _text;

    public string GetCommenterName()
    {
        return _commentName;
    }

    public void SetCommenterName(string value)
    {
        _commentName = value;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string value)
    {
        _text = value;
    }
}

public class Video
{
    private string title;
    private string author;
    private int duration;
    private List<Comment> comments;

    public string GetTitle()
    {
        return title;
    }

    public void SetTitle(string value)
    {
        title = value;
    }

    public string GetAuthor()
    {
        return author;
    }

    public void SetAuthor(string value)
    {
        author = value;
    }

    public int GetDuration()
    {
        return duration;
    }

    public void SetDuration(int value)
    {
        duration = value;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public void SetComments(List<Comment> value)
    {
        comments = value;
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }
}

