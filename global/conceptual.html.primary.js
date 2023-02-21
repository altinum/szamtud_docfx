exports.transform = function (model) {
    model._extra_property = "Hello world";
    return model;
}
