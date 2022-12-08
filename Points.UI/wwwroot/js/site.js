
function GetInitData() {
    $.ajax({
        type: 'GET',
        url: 'points/getdots',
        success: function (response) {
            DrawStageAndElements(response);
        },
        error: function (error) {
            console.log(error)
            alert('Что-то пошло не так');
        }
    });
};

function DrawStageAndElements(response) {
    var width = window.innerWidth;
    var height = window.innerHeight;

    var stage = new Konva.Stage({
        container: 'container',
        width: width,
        height: height,
    });

    stage.on('click', (e) => {

        const clickedOnEmptyArea = e.target === stage;
        if (!clickedOnEmptyArea) {
            return;
        }

        let model = {
            PositionX: window.event.clientX,
            PositionY: window.event.clientY,
            Radius: 25,
            Color: 'Red',
            Comments: [{ Text: 'test comment', BackgroundColor: 'yellow' }]
        };

        $.ajax({
            type: 'POST',
            url: 'points/create',
            data: model,
            success: function (response) {
                GetInitData();
            },
            error: function (err) {
                console.log(err);
                alert('Упс, что-то пошло не так')
            }
        })
    });


    var layer = new Konva.Layer();
    for (var i = 0; i < response.length; i++) {

        var group = new Konva.Group();

        var circle = new Konva.Circle({
            x: response[i].positionX,
            y: response[i].positionY,
            radius: response[i].radius,
            fill: response[i].color,
            name: response[i].id + ''
        });

        circle.on('dblclick', function (e) {

            const clickedOnEmptyArea = e.target === stage;
            if (clickedOnEmptyArea) {
                return;
            }

            var id = e.currentTarget.attrs.name;
            $.ajax({
                url: "points/delete",
                type: "DELETE",
                datatype: "text",
                data: { dotId: id },
                success: function (response) {
                    if (response) {
                        var shapes = stage.find('.' + id);
                        for (var i = 0; i < shapes.length; i++) {
                            shapes[i].destroy();
                        }
                        layer.draw();
                    } else {
                        alert("Что-то пошло не так")
                    }
                }
            });
        });

        group.add(circle)
        var starPosition = response[i].positionY + response[i].radius + 5;
        for (var j = 0; j < response[i].comments.length; j++) {
            var simpleLabel = new Konva.Label({
                x: (response[i].positionX - (response[i].comments[j].text.length * 5.1)),
                y: starPosition,
            });

            simpleLabel.add(
                new Konva.Tag({
                    fill: response[i].comments[j].backgroundColor,
                    stroke: "Grey",
                    name: response[i].id + ''
                })
            );

            simpleLabel.add(
                new Konva.Text({
                    text: response[i].comments[j].text,
                    fontFamily: 'Calibri',
                    fontSize: 18,
                    padding: 5,
                    fill: 'Green',
                    name: response[i].id + ''
                })
            );
            group.add(simpleLabel)
            starPosition += 32;
        }
        layer.add(group);
    }
    stage.add(layer);
};

GetInitData();

