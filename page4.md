---
layout: post
category : lessons
tagline: "Supporting tagline"
tags : [intro, beginner, jekyll, tutorial]
---

{% assign allPosts = (site.posts | where: 'category', 'project') %}

    {% for post in allPosts %}
### {{post.title}}  [![Build Status]({{post.status}})]({{post.cilocation}})

{{post.excerpt}}

[more...]({{ site.baseurl }}{{ post.url }})
    {% endfor %}


