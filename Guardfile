# A sample Guardfile
# More info at https://github.com/guard/guard#readme

guard :shell, :all_on_start => true do
  watch(%r{^SignatureSurvey/.+.cs$}) do |m|
    `SignatureSurvey/bin/Debug/SignatureSurvey.exe #{m[0]}`
  end
end
