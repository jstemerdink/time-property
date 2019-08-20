define([
    "dojo/_base/declare",
    "dojo/date/locale", // locale.format
    "dojo/date/stamp", // stamp.fromISOString stamp.toISOString
    "dijit/_CssStateMixin",
    "dijit/_Widget",
    "dijit/_TemplatedMixin",
    "dijit/_WidgetsInTemplateMixin",

    "dijit/form/TimeTextBox",
    "epi/shell/widget/_ValueRequiredMixin"

], function (declare, locale, stamp,

    _CssStateMixin,
    _Widget,
    _TemplatedMixin,
    _WidgetsInTemplateMixin,

    TimeTextBox,
    _ValueRequiredMixin
) {

    var a = declare([TimeTextBox], {
        _setValueAttr: function (value, priorityChange, formattedValue) {
            if (value instanceof Date || !value) {
                this.inherited(arguments);
                return;
            }
            var date = new Date();
            date.setSeconds(0);
            var timeSpan = value.split(":");
            date.setMinutes(parseInt(timeSpan[1]));
            date.setHours(parseInt(timeSpan[0]));
            this.set("value", date);
        },

        _getValueAttr: function () {
            var result = this.inherited(arguments);
            if (result === null) {
                return null;
            }
            var hours = result.getHours() + "";
            if (hours.length < 2) {
                hours = "0" + hours;
            }
            var minutes = result.getMinutes() + "";
            if (minutes.length < 2) {
                minutes = "0" + minutes;
            }
            return hours + ":" + minutes + ":00";
        },

        serialize: function (/*anything*/ val, /*Object?*/ options) {
            return val;
        }
    });


    return declare([_Widget, _TemplatedMixin, _WidgetsInTemplateMixin, _CssStateMixin, _ValueRequiredMixin], {

        templateString: "<div class='dijitInline' tabindex='-1' role='presentation'>\
                            <div data-dojo-attach-point='stateNode, tooltipNode'>\
                            </div>\
                        </div>",

        baseClass: "epiTimePicker",

        value: null,

        onChange: function (value) {
            // Event
        },

        postCreate: function () {
            this.inherited(arguments);

            this.timePicker = new TimeTextBox(this.params);
            this.timePicker.placeAt(this.stateNode);
            if (this._value) {
                this.timePicker.set("value", this._value);
            }

            this.connect(this.timePicker, "onChange", this._onTimePickerChanged);
        },

        isValid: function () {
            // summary:
            //    Check if widget's value is valid.
            // tags:
            //    protected, override

            return !this.required || this.timePicker.isValid();
        },

        // Setter for value property
        _setValueAttr: function (value) {
            this._setValue(value, true);
        },

        _getValueAttr: function () {
            // summary:
            //   Returns the textbox value as array.
            // tags:
            //    protected, override

            var val = this.timePicker && this.timePicker.get("value");
            return this._getTimeSpanValue(val);
        },

        _setReadOnlyAttr: function (value) {
            this._set("readOnly", value);
            if (this.timePicker) {
                this.timePicker.set("readOnly", value);
            }
        },

        _onTimePickerChanged: function (value) {
            this._setValue(value, false);
        },

        _setValue: function (value, updateTimePicker) {
            // Assume value is an array
            var timeSpanValue = value;

            if (value instanceof Date) {

                // Split list
                timeSpanValue = this._getTimeSpanValue(value);

            } else if (!value) {
                // use empty array for empty value
                timeSpanValue = null;
            }

            if (this._started && epi.areEqual(this.value, timeSpanValue)) {
                return;
            }

            // set value to this widget (and notify observers)
            this._set("value", timeSpanValue);

            if (updateTimePicker) {
                var parsedValue = this._parseDateValue(timeSpanValue);
                if (parsedValue) {
                    this._value = parsedValue;
                    this.timePicker && this.timePicker.set("value", parsedValue);
                }
            }

            if (this._started && this.validate()) {
                // Trigger change event
                this.onChange(timeSpanValue);
            }
        },

        _getTimeSpanValue: function (date) {
            if (!date) {
                return null;
            }
            var hours = date.getHours() + "";
            if (hours.length < 2) {
                hours = "0" + hours;
            }
            var minutes = date.getMinutes() + "";
            if (minutes.length < 2) {
                minutes = "0" + minutes;
            }
            return hours + ":" + minutes + ":00";
        },

        _parseDateValue: function (str) {
            if (!str) {
                return null;
            }

            var date = new Date();
            date.setSeconds(0);
            var timeSpan = str.split(":");
            date.setMinutes(parseInt(timeSpan[1]));
            date.setHours(parseInt(timeSpan[0]));
            return date;
        }
    });
});
